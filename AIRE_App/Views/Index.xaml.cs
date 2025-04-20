using AIRE_App.Interfaces;
using AIRE_App.Services;
using AIRE_App.ViewModels;

namespace AIRE_App.Views;

public partial class IndexView : ContentPage
{
    private const String sqlAIServiceKey = "SqlAIService";

    private const String chatAIServiceKey = "ChatAIService";

    private readonly App app = Application.Current as App;

    public IndexView(AIStatusViewModel aiStatusViewModel,
        [FromKeyedServices(sqlAIServiceKey)] IAIService sqlAIService,
        [FromKeyedServices(chatAIServiceKey)] IAIService chatAIService)
    {
        InitializeComponent();

        if (Preferences.ContainsKey(sqlAIServiceKey))
        {
            var id = Preferences.Get(sqlAIServiceKey, String.Empty);
            sqlAIService.SetID(id);
        }

        if (Preferences.ContainsKey(chatAIServiceKey))
        {
            var id = Preferences.Get(chatAIServiceKey, String.Empty);
            chatAIService.SetID(id);
        }

        JSONService.InitMessage(aiStatusViewModel);
    }

    private async void OnClicked(Object sender, EventArgs eventArgs)
    {
        // await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("/Region");
    }
}