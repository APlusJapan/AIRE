using AIRE_App.Services;

namespace AIRE_App.Views;

public partial class IndexView : ContentPage
{
    private readonly App app = Application.Current as App;

    public IndexView()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(Object sender, EventArgs eventArgs)
    {
        await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("Search/1st");
    }
}