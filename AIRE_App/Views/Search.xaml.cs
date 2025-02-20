using System.Collections.ObjectModel;
using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.AspNetCore.Http;

namespace AIRE_App.Views;

public partial class SearchView : ContentPage
{
    private readonly SearchViewModel viewModel;

    private readonly App app = Application.Current as App;

    private readonly ObservableCollection<ItemViewModel> emptyCollection = [];

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> AreaGroups;

    private ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> StationGroups;

    public SearchView()
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
            if (StationGroups == null)
            {
                StationGroups = new(railways.Select(railway => new GroupViewModel<GroupViewModel<ItemViewModel>>()
                {
                    ID = railway.RailwayName,
                    Name = $"[{railway.RailwayCompany}] {railway.RailwayName}",
                    LoadItems = LoadStation
                }));
            }

            viewModel.Groups = StationGroups;

            app.Session.SetString(nameof(SearchType), SearchType.Station.ToString());
        }

        foreach (var group in viewModel.Groups)
        {
            group.IsChecked = false;
            group.IsExpanded = false;
        }
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
            if (AreaGroups == null)
            {
                AreaGroups = new(prefectures.Select(prefecture => new GroupViewModel<GroupViewModel<ItemViewModel>>()
                {
                    ID = prefecture.PrefectureId,
                    Name = prefecture.PrefectureName,
                    LoadItems = LoadAeras
                }));
            }

            viewModel.Groups = AreaGroups;

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

            prefecture.Items = new(stations
                .Select(station => new GroupViewModel<ItemViewModel>()
                {
                    ID = station.StationId,
                    Name = station.StationName,
                    ParentItemCheck = prefecture.SubItemCheck
                }));
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

            prefecture.Items = new(areas
                .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                    (String.IsNullOrWhiteSpace(area.ParentAreaId) || area.ParentAreaId == area.AreaId))
                .Select(area => new GroupViewModel<ItemViewModel>()
                {
                    ID = area.AreaId,
                    Name = area.AreaName,
                    ParentItemCheck = prefecture.SubItemCheck,
                    Items = String.IsNullOrWhiteSpace(area.ParentAreaId) ? null : emptyCollection
                }));

            foreach (var groupItem in prefecture.Items)
            {
                if (groupItem.Items == emptyCollection)
                {
                    groupItem.Items = new(areas
                        .Where(area => String.IsNullOrWhiteSpace(area.RevisedAreaId) &&
                            area.ParentAreaId == groupItem.ID &&
                            area.ParentAreaId != area.AreaId)
                        .Select(subitem => new ItemViewModel()
                        {
                            ID = subitem.AreaId,
                            Name = subitem.AreaName,
                            ParentItemCheck = groupItem.SubItemCheck
                        }));
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

    private async void OnClicked(Object sender, EventArgs e)
    {
        await DisplayAlert("Log", String.Join(",", viewModel.Groups.Where(group => group.IsChecked && group.Items.All(item => item.IsChecked)).Select(group => group.Name).ToList()), "OK");
    }
}
