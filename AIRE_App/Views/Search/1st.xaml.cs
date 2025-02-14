using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.AspNetCore.Http;

namespace AIRE_App.Views;

public partial class Search1stView : ContentPage
{

    private readonly Search1stViewModel viewModel;

    private readonly App app = Application.Current as App;

    public Search1stView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();
    }

    private void AreaSearch(Object sender, EventArgs eventArgs)
    {
        if (!app.Items.TryGetValue(nameof(Prefecture), out Object value)
            || value is not Prefecture[])
        {
            value = app.Items[nameof(Prefecture)] = DatabaseService.GetAireDbContext().Prefectures.ToArray();
        }

        var prefectures = value as Prefecture[];

        viewModel.Groups = new(prefectures.Select(prefecture => new GroupViewModel<GroupViewModel<ItemViewModel>>()
        {
            Name = prefecture.PrefectureName
        }));

        app.Session.SetString(nameof(SearchType), SearchType.Area.ToString());
    }
}
