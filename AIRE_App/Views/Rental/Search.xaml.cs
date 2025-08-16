using System.Collections.ObjectModel;
using System.Diagnostics;
using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Syncfusion.Maui.Toolkit.Picker;

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

    private async void OnSelectionChanged_Group(Object sender, SelectionChangedEventArgs eventArgs)
    {
        if (eventArgs.CurrentSelection.Count == 0) return;

        var collectionView = sender as CollectionView;

        foreach (GroupViewModel<GroupViewModel<ItemViewModel>> currentItem in eventArgs.CurrentSelection)
        {
            if (currentItem.Items != null)
            {
                currentItem.IsExpanded = !currentItem.IsExpanded;
            }
            else
            {
                currentItem.IsChecked = !currentItem.IsChecked;
            }
        }

        await Task.Yield();
        collectionView.SelectedItem = null;
    }

    private async void OnSelectionChanged_GroupItem(Object sender, SelectionChangedEventArgs eventArgs)
    {
        if (eventArgs.CurrentSelection.Count == 0) return;

        var collectionView = sender as CollectionView;

        foreach (GroupViewModel<ItemViewModel> currentItem in eventArgs.CurrentSelection)
        {
            if (searchType == SearchType.Station)
            {
                LoadStation(currentItem);
            }

            if (currentItem.Items != null)
            {
                currentItem.IsExpanded = !currentItem.IsExpanded;
            }
            else
            {
                currentItem.IsChecked = !currentItem.IsChecked;
            }
        }

        await Task.Yield();
        collectionView.SelectedItem = null;
    }

    private async void OnSelectionChanged_Item(Object sender, SelectionChangedEventArgs eventArgs)
    {
        if (eventArgs.CurrentSelection.Count == 0) return;

        var collectionView = sender as CollectionView;

        foreach (ItemViewModel currentItem in eventArgs.CurrentSelection)
        {
            currentItem.IsChecked = !currentItem.IsChecked;
        }

        await Task.Yield();
        collectionView.SelectedItem = null;
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

    void TapGestureRecognizer_Prefecture(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_Prefecture(sender, eventArgs);
    }

    private void OkButtonClicked_Prefecture(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Prefecture(sender, eventArgs);

        viewModel.PrefectureIndex = viewModel.PrefectureSfPickerIndex;
    }

    private void CancelButtonClicked_Prefecture(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Prefecture(sender, eventArgs);
    }

    private void SelectionChanged_Prefecture(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.PrefectureSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_Prefecture(Object sender, EventArgs eventArgs)
    {
        viewModel.PrefecturePickerIsOpen = !viewModel.PrefecturePickerIsOpen;
    }

    void TapGestureRecognizer_YachinMin(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_YachinMin(sender, eventArgs);
    }

    private void OkButtonClicked_YachinMin(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_YachinMin(sender, eventArgs);

        viewModel.YachinMinIndex = viewModel.YachinMinSfPickerIndex;
    }

    private void CancelButtonClicked_YachinMin(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_YachinMin(sender, eventArgs);
    }

    private void SelectionChanged_YachinMin(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.YachinMinSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_YachinMin(Object sender, EventArgs eventArgs)
    {
        viewModel.YachinMinPickerIsOpen = !viewModel.YachinMinPickerIsOpen;
    }

    void TapGestureRecognizer_YachinMax(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_YachinMax(sender, eventArgs);
    }

    private void OkButtonClicked_YachinMax(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_YachinMax(sender, eventArgs);

        viewModel.YachinMaxIndex = viewModel.YachinMaxSfPickerIndex;
    }

    private void CancelButtonClicked_YachinMax(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_YachinMax(sender, eventArgs);
    }

    private void SelectionChanged_YachinMax(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.YachinMaxSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_YachinMax(Object sender, EventArgs eventArgs)
    {
        viewModel.YachinMaxPickerIsOpen = !viewModel.YachinMaxPickerIsOpen;
    }

    void TapGestureRecognizer_Toho(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_Toho(sender, eventArgs);
    }

    private void OkButtonClicked_Toho(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Toho(sender, eventArgs);

        viewModel.TohoIndex = viewModel.TohoSfPickerIndex;
    }

    private void CancelButtonClicked_Toho(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Toho(sender, eventArgs);
    }

    private void SelectionChanged_Toho(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.TohoSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_Toho(Object sender, EventArgs eventArgs)
    {
        viewModel.TohoPickerIsOpen = !viewModel.TohoPickerIsOpen;
    }

    void TapGestureRecognizer_MenMin(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_MenMin(sender, eventArgs);
    }

    private void OkButtonClicked_MenMin(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_MenMin(sender, eventArgs);

        viewModel.MenMinIndex = viewModel.MenMinSfPickerIndex;
    }

    private void CancelButtonClicked_MenMin(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_MenMin(sender, eventArgs);
    }

    private void SelectionChanged_MenMin(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.MenMinSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_MenMin(Object sender, EventArgs eventArgs)
    {
        viewModel.MenMinPickerIsOpen = !viewModel.MenMinPickerIsOpen;
    }

    void TapGestureRecognizer_MenMax(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_MenMax(sender, eventArgs);
    }

    private void OkButtonClicked_MenMax(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_MenMax(sender, eventArgs);

        viewModel.MenMaxIndex = viewModel.MenMaxSfPickerIndex;
    }

    private void CancelButtonClicked_MenMax(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_MenMax(sender, eventArgs);
    }

    private void SelectionChanged_MenMax(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.MenMaxSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_MenMax(Object sender, EventArgs eventArgs)
    {
        viewModel.MenMaxPickerIsOpen = !viewModel.MenMaxPickerIsOpen;
    }

    void TapGestureRecognizer_Chikunensu(Object sender, TappedEventArgs eventArgs)
    {
        PickerSwitch_Chikunensu(sender, eventArgs);
    }

    private void OkButtonClicked_Chikunensu(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Chikunensu(sender, eventArgs);

        viewModel.ChikunensuIndex = viewModel.ChikunensuSfPickerIndex;
    }

    private void CancelButtonClicked_Chikunensu(Object sender, EventArgs eventArgs)
    {
        PickerSwitch_Chikunensu(sender, eventArgs);
    }

    private void SelectionChanged_Chikunensu(Object sender, PickerSelectionChangedEventArgs eventArgs)
    {
        viewModel.ChikunensuSfPickerIndex = eventArgs.NewValue;
    }

    private void PickerSwitch_Chikunensu(Object sender, EventArgs eventArgs)
    {
        viewModel.ChikunensuPickerIsOpen = !viewModel.ChikunensuPickerIsOpen;
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
