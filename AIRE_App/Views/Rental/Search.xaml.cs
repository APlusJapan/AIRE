using System.Collections.ObjectModel;
using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;

namespace AIRE_App.Views;

public partial class RentalSearchView : ContentPage
{
    private SearchType searchType = SearchType.None;

    private readonly RentalSearchViewModel viewModel;

    private readonly App app = Application.Current as App;

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> areaGroups;

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> stationGroups;

    public RentalSearchView()
    {
        InitializeComponent();

        BindingContext = viewModel = new(LoadPrefectures());
    }

    private List<ItemViewModel> LoadPrefectures()
    {
        if (!app.Items.TryGetValue(nameof(Prefecture), out Object value)
            || value is not Prefecture[])
        {
            value = app.Items[nameof(Prefecture)] = DatabaseService.GetAireDbContext().Prefectures.ToArray();
        }

        var prefectures = value as Prefecture[];

        return [.. prefectures.Select(prefecture => new ItemViewModel()
        {
            ID = prefecture.PrefectureId,
            Name = prefecture.PrefectureName
        })];
    }

    private void StationSearch(Object sender, EventArgs eventArgs)
    {
        if (!app.Items.TryGetValue(nameof(RailwayInfo), out Object value)
            || value is not RailwayInfo[])
        {
            value = app.Items[nameof(RailwayInfo)] = DatabaseService.GetAireDbContext().RailwayInfos.ToArray();
        }

        var railwayInfos = value as RailwayInfo[];

        if (searchType != SearchType.Station)
        {
            if (stationGroups == null)
            {
                var prefectureID = viewModel.Prefectures[viewModel.PrefectureIndex].ID;

                stationGroups = [.. railwayInfos.Where(railwayInfo => railwayInfo.PrefectureId == prefectureID)
                    .GroupBy(railwayInfo => railwayInfo.RailwayCompany)
                    .Select(railwayInfoGroup =>
                    {
                        var currentGroup = new GroupViewModel<GroupViewModel<ItemViewModel>>()
                        {
                            Name = railwayInfoGroup.Key
                        };

                        currentGroup.Items = [.. railwayInfoGroup.Select(railwayInfoItem => new GroupViewModel<ItemViewModel>()
                        {
                            ID = railwayInfoGroup.Key,
                            Name = railwayInfoItem.RailwayName,
                            ParentItemCheck = currentGroup.SubItemCheck,
                            LoadItems = LoadStation
                        })];

                        return currentGroup;
                    })];
            }

            viewModel.Groups = stationGroups;

            searchType = SearchType.Station;
        }

        foreach (var group in viewModel.Groups)
        {
            group.IsChecked = false;
            group.IsExpanded = false;

            if (group.Items != null)
            {
                foreach (var groupItem in group.Items)
                {
                    groupItem.IsExpanded = false;
                }
            }
        }

        viewModel.IsGroupReady = true;
    }

    private void AreaSearch(Object sender, EventArgs eventArgs)
    {
        var prefectureID = viewModel.Prefectures[viewModel.PrefectureIndex].ID;

        if (!app.Items.TryGetValue(prefectureID, out Object value)
                || value is not Area[])
        {
            value = app.Items[prefectureID] = DatabaseService.GetAireDbContext().Areas
                .Where(area => area.PrefectureId == prefectureID).ToArray();
        }

        var areas = value as Area[];

        if (searchType != SearchType.Area)
        {
            if (areaGroups == null)
            {
                areaGroups = [.. areas
                    .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                        (String.IsNullOrWhiteSpace(area.ParentAreaId) || area.ParentAreaId == area.AreaId))
                    .Select(area =>
                    {
                        var currentGroup = new GroupViewModel<GroupViewModel<ItemViewModel>>()
                        {
                            ID = area.AreaId,
                            Name = area.AreaName,
                        };

                        if(area.ParentAreaId == area.AreaId)
                        {
                            currentGroup.Items = [.. areas
                                .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                                    area.ParentAreaId == currentGroup.ID &&
                                    area.ParentAreaId != area.AreaId)
                                .Select(subitem => new GroupViewModel<ItemViewModel>()
                                {
                                    ID = subitem.AreaId,
                                    Name = subitem.AreaName,
                                    ParentItemCheck = currentGroup.SubItemCheck
                                })];
                        }

                        return currentGroup;
                    })];
            }

            viewModel.Groups = areaGroups;

            searchType = SearchType.Area;
        }

        foreach (var group in viewModel.Groups)
        {
            group.IsChecked = false;
            group.IsExpanded = false;
        }

        viewModel.IsGroupReady = true;
    }

    private void LoadStation(GroupViewModel<ItemViewModel> railwayInfoItem)
    {
        if (railwayInfoItem.Items == null)
        {
            var stationRailwayInfo = $"{railwayInfoItem.ID},{railwayInfoItem.Name}";

            if (!app.Items.TryGetValue(stationRailwayInfo, out Object value)
                || value is not Station[])
            {
                value = app.Items[stationRailwayInfo] = DatabaseService.GetAireDbContext().Stations
                    .Where(station => station.RailwayCompany == railwayInfoItem.ID &&
                        station.RailwayName == railwayInfoItem.Name).ToArray();
            }

            var stations = value as Station[];

            railwayInfoItem.Items = [.. stations
                .Select(station => new GroupViewModel<ItemViewModel>()
                {
                    ID = station.StationId,
                    Name = station.StationName,
                    ParentItemCheck = railwayInfoItem.SubItemCheck
                })];
        }
    }

    private void OnItemTapped_Group(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as GroupViewModel<GroupViewModel<ItemViewModel>>;

        if (item.Items != null)
        {
            item.IsExpanded = !item.IsExpanded;
        }
        else
        {
            item.IsChecked = !item.IsChecked;
        }
    }

    private void OnItemTapped_GroupItem(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as GroupViewModel<ItemViewModel>;

        if (searchType == SearchType.Station)
        {
            LoadStation(item);
        }

        if (item.Items != null)
        {
            item.IsExpanded = !item.IsExpanded;
        }
        else
        {
            item.IsChecked = !item.IsChecked;
        }
    }

    private void OnItemTapped_Item(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as ItemViewModel;

        item.IsChecked = !item.IsChecked;
    }

    private void OnSelectedIndexChanged_Load(Object sender, EventArgs eventArgs)
    {
        areaGroups = null;
        stationGroups = null;
        viewModel.Groups = null;
        searchType = SearchType.None;
        viewModel.SearchType = "None";
        viewModel.IsGroupReady = false;
        OnCheckedChanged_Load(sender, eventArgs);
    }

    private void OnCheckedChanged_Load(Object sender, EventArgs eventArgs)
    {
        switch (viewModel.SearchType)
        {
            case "Station":
                {
                    StationSearch(sender, eventArgs);
                    break;
                }
            case "Area":
                {
                    AreaSearch(sender, eventArgs);
                    break;
                }
        }
    }

    private async void OnClicked_Submit(Object sender, EventArgs eventArgs)
    {
        List<ItemViewModel> queryItem = [];

        switch (searchType)
        {
            case SearchType.Station:
                {
                    foreach (var group in viewModel.Groups)
                    {
                        if (group.IsChecked)
                        {
                            foreach (var groupItem in group.Items)
                            {
                                if (groupItem.IsChecked)
                                {
                                    foreach (var item in groupItem.Items)
                                    {
                                        if (item.IsChecked)
                                        {
                                            queryItem.Add(item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            case SearchType.Area:
                {
                    foreach (var group in viewModel.Groups)
                    {
                        if (group.IsChecked)
                        {
                            if (group.Items == null)
                            {
                                queryItem.Add(group);
                            }
                            else
                            {
                                bool groupSelected = true;

                                foreach (var groupItem in group.Items)
                                {
                                    if (groupItem.IsChecked)
                                    {
                                        queryItem.Add(groupItem);
                                    }
                                    else
                                    {
                                        groupSelected = false;
                                    }
                                }

                                if (groupSelected)
                                {
                                    queryItem.Add(group);
                                }
                            }
                        }
                    }
                    break;
                }
        }

        if(queryItem.Count() == 0)
        {
            await DisplayAlert("駅・エリア", "駅・エリアを選択してください", "OK");
        }
        else
        { 
            await Shell.Current.GoToAsync("Rental/List?sqlModel=False", new Dictionary<String, Object>
            {
                { "searchType", searchType },
                { "queryItem", queryItem },
                { "yachinMin", viewModel.YachinMin[viewModel.YachinMinIndex] },
                { "yachinMax", viewModel.YachinMax[viewModel.YachinMaxIndex] },
                { "noKanrihi", viewModel.NoKanrihi },
                { "noReikin", viewModel.NoReikin },
                { "noShikikin", viewModel.NoShikikin },
                { "oneroom", viewModel.Oneroom },
                { "room1k", viewModel.Room1k },
                { "room1dk", viewModel.Room1dk },
                { "room1ldk", viewModel.Room1ldk },
                { "room2k", viewModel.Room2k },
                { "room2dk", viewModel.Room2dk },
                { "room2ldk", viewModel.Room2ldk },
                { "room3k", viewModel.Room3k },
                { "room3dk", viewModel.Room3dk },
                { "room3ldk", viewModel.Room3ldk },
                { "room4k", viewModel.Room4k },
                { "room4dk", viewModel.Room4dk },
                { "room4ldk", viewModel.Room4ldk },
                { "room5k", viewModel.Room5k },
                { "mansion", viewModel.Mansion },
                { "apartment", viewModel.Apartment },
                { "detachedHouse", viewModel.DetachedHouse },
                { "toho", viewModel.Toho[viewModel.TohoIndex] },
                { "menMin", viewModel.MenMin[viewModel.MenMinIndex] },
                { "menMax", viewModel.MenMax[viewModel.MenMaxIndex] },
                { "chikunensu", viewModel.Chikunensu[viewModel.ChikunensuIndex] },
                { "tyuurin", viewModel.Tyuurin },
                { "btbetu", viewModel.Btbetu },
                { "petka", viewModel.Petka },
                { "secondFloor", viewModel.SecondFloor },
                { "situsentaku", viewModel.Situsentaku },
                { "eEakon", viewModel.Eakon },
                { "outorok", viewModel.Outorok },
                { "furoringu", viewModel.Furoringu },
                { "withFloorPlan", viewModel.WithFloorPlan },
                { "withVideo", viewModel.WithVideo },
                { "withPanorama", viewModel.WithPanorama },
                { "noTeisyaku", viewModel.NoTeisyaku }
            });
        }
    }
}
