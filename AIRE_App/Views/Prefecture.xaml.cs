using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.AspNetCore.Http;

namespace AIRE_App.Views;

public partial class PrefectureView : ContentPage
{
    private readonly PrefectureViewModel viewModel;

    private readonly App app = Application.Current as App;

    public PrefectureView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();

        viewModel.LoadPrefectures += LoadPrefectures;
    }

    private void LoadPrefectures(RegionType regionType)
    {
        if (!app.Items.TryGetValue(nameof(Prefecture), out Object value)
            || value is not Prefecture[])
        {
            value = app.Items[nameof(Prefecture)] = DatabaseService.GetAireDbContext().Prefectures.ToArray();
        }

        var prefectures = value as Prefecture[];

        var regionToPrefectureIDArray = Maps.RegionToPrefectureIDMap[regionType];

        viewModel.Items = [.. prefectures.Where(prefecture => regionToPrefectureIDArray.IndexOf(prefecture.PrefectureId) > -1)
            .Select(prefecture => new ItemViewModel()
            {
                ID = prefecture.PrefectureId,
                Name = prefecture.PrefectureName
            })];
    }

    private async void OnItemTapped_Item(Object sender, ItemTappedEventArgs eventArgs)
    {
        var item = eventArgs.Item as ItemViewModel;

        app.Session.SetString(nameof(Prefecture), item.ID);

        await Shell.Current.GoToAsync("/Rental/Search");
    }
}