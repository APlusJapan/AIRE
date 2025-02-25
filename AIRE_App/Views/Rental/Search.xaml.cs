using System.Collections.ObjectModel;
using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.AspNetCore.Http;

namespace AIRE_App.Views;

public partial class RentalSearchView : ContentPage
{
    private readonly RentalSearchViewModel viewModel;

    private readonly App app = Application.Current as App;

    private readonly ObservableCollection<ItemViewModel> emptyCollection = [];

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> areaGroups;

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> stationGroups;

    public RentalSearchView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();
    }

    private void StationSearch(Object sender, EventArgs eventArgs)
    {
        if (!app.Items.TryGetValue(nameof(Station.RailwayName), out Object value)
            || value is not Station[])
        {
            value = app.Items[nameof(Station.RailwayName)] = DatabaseService.GetAireDbContext().Stations
                .Select(railway => new Station()
                {
                    RailwayName = railway.RailwayName,
                    RailwayCompany = railway.RailwayCompany
                }).Distinct()
                .OrderBy(railway => railway.RailwayCompany).ThenBy(railway => railway.RailwayName).ToArray();
        }

        var railways = value as Station[];

        if (app.Session.GetString(nameof(SearchType)) != SearchType.Station.ToString())
        {
            if (stationGroups == null)
            {
                stationGroups = [.. railways.Select(railway => new GroupViewModel<GroupViewModel<ItemViewModel>>()
                {
                    ID = railway.RailwayName,
                    Name = $"[{railway.RailwayCompany}] {railway.RailwayName}",
                    LoadItems = LoadStation
                })];
            }

            viewModel.Groups = stationGroups;

            app.Session.SetString(nameof(SearchType), SearchType.Station.ToString());
        }

        foreach (var group in viewModel.Groups)
        {
            group.IsChecked = false;
            group.IsExpanded = false;
        }

        viewModel.IsGroupsExpanded = true;
    }

    private void AreaSearch(Object sender, EventArgs eventArgs)
    {
        if (!app.Items.TryGetValue(nameof(Prefecture), out Object value)
            || value is not Prefecture[])
        {
            value = app.Items[nameof(Prefecture)] = DatabaseService.GetAireDbContext().Prefectures.ToArray();
        }

        var prefectures = value as Prefecture[];

        if (app.Session.GetString(nameof(SearchType)) != SearchType.Area.ToString())
        {
            if (areaGroups == null)
            {
                areaGroups = [.. prefectures.Select(prefecture => new GroupViewModel<GroupViewModel<ItemViewModel>>()
                {
                    ID = prefecture.PrefectureId,
                    Name = prefecture.PrefectureName,
                    LoadItems = LoadAeras
                })];
            }

            viewModel.Groups = areaGroups;

            app.Session.SetString(nameof(SearchType), SearchType.Area.ToString());
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

        viewModel.IsGroupsExpanded = true;
    }

    private void LoadStation(GroupViewModel<GroupViewModel<ItemViewModel>> prefecture)
    {
        if (prefecture.Items == null)
        {
            if (!app.Items.TryGetValue(prefecture.ID, out Object value)
                || value is not Station[])
            {
                value = app.Items[prefecture.ID] = DatabaseService.GetAireDbContext().Stations
                    .Where(station => station.RailwayName == prefecture.ID).ToArray();
            }

            var stations = value as Station[];

            prefecture.Items = [.. stations
                .Select(station => new GroupViewModel<ItemViewModel>()
                {
                    ID = station.StationId,
                    Name = station.StationName,
                    ParentItemCheck = prefecture.SubItemCheck
                })];
        }
    }

    private void LoadAeras(GroupViewModel<GroupViewModel<ItemViewModel>> prefecture)
    {
        if (prefecture.Items == null)
        {
            if (!app.Items.TryGetValue(prefecture.ID, out Object value)
                || value is not Area[])
            {
                value = app.Items[prefecture.ID] = DatabaseService.GetAireDbContext().Areas
                    .Where(area => area.PrefectureId == prefecture.ID).ToArray();
            }

            var areas = value as Area[];

            prefecture.Items = [.. areas
                .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                    (String.IsNullOrWhiteSpace(area.ParentAreaId) || area.ParentAreaId == area.AreaId))
                .Select(area => new GroupViewModel<ItemViewModel>()
                {
                    ID = area.AreaId,
                    Name = area.AreaName,
                    ParentItemCheck = prefecture.SubItemCheck,
                    Items = String.IsNullOrWhiteSpace(area.ParentAreaId) ? null : emptyCollection
                })];

            foreach (var groupItem in prefecture.Items)
            {
                if (groupItem.Items == emptyCollection)
                {
                    groupItem.Items = [.. areas
                        .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                            area.ParentAreaId == groupItem.ID &&
                            area.ParentAreaId != area.AreaId)
                        .Select(subitem => new ItemViewModel()
                        {
                            ID = subitem.AreaId,
                            Name = subitem.AreaName,
                            ParentItemCheck = groupItem.SubItemCheck
                        })];
                }
            }
        }
    }

    private void OnItemTapped_Group(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as GroupViewModel<GroupViewModel<ItemViewModel>>;

        switch (Enum.Parse<SearchType>(app.Session.GetString(nameof(SearchType))))
        {
            case SearchType.Station:
                {
                    LoadStation(item);
                    break;
                }
            case SearchType.Area:
                {
                    LoadAeras(item);
                    break;
                }
        }

        item.IsExpanded = !item.IsExpanded;
    }

    private void OnItemTapped_GroupItem(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as GroupViewModel<ItemViewModel>;

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

    private async void OnClicked_Submit(Object sender, EventArgs e)
    {
        List<ItemViewModel> queryItem = [];

        if(viewModel.Groups != null)
        {
            foreach (var group in viewModel.Groups)
            {
                if (group.IsChecked)
                {
                    foreach (var groupItem in group.Items)
                    {
                        if (groupItem.IsChecked)
                        {
                            if (groupItem.Items == null)
                            {
                                queryItem.Add(groupItem);
                            }
                            else
                            {
                                bool groupItemSelected = true;

                                foreach (var item in groupItem.Items)
                                {
                                    if (item.IsChecked)
                                    {
                                        queryItem.Add(item);
                                    }
                                    else
                                    {
                                        groupItemSelected = false;
                                    }
                                }

                                if (groupItemSelected)
                                {
                                    queryItem.Add(groupItem);
                                }
                            }
                        }
                    }
                }
            }
        }

        await Shell.Current.GoToAsync("Rental/List", new Dictionary<String, Object>
        {
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
