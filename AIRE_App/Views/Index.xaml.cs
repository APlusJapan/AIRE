namespace AIRE_App.Views;

public partial class IndexView : ContentPage
{
    private readonly App app = Application.Current as App;

    public IndexView()
    {
        InitializeComponent();
    }

    private async void OnClicked(Object sender, EventArgs eventArgs)
    {
        // await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("/Rental/Search");
    }
}