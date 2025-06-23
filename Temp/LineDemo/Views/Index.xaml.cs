namespace AIRE_App.Views;

public partial class IndexView : ContentPage
{
    private readonly App app = Application.Current as App;

    public IndexView()
    {
        InitializeComponent();
    }

    private async void OnClicked_A(Object sender, EventArgs eventArgs)
    {
        await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("Line", new Dictionary<String, Object>
        {
            { "companyId", "A" },
            { "staffId", "A" }
        });
    }

    private async void OnClicked_B(Object sender, EventArgs eventArgs)
    {
        await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("Line", new Dictionary<String, Object>
        {
            { "companyId", "B" },
            { "staffId", "B" }
        });
    }

    private async void OnClicked_C(Object sender, EventArgs eventArgs)
    {
        await DisplayAlert("Device Unique ID", app.Session.Id, "OK");

        await Shell.Current.GoToAsync("Line", new Dictionary<String, Object>
        {
            { "companyId", "C" },
            { "staffId", "C" }
        });
    }
}