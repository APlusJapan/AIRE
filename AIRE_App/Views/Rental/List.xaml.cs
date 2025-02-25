using AIRE_App.ViewModels;

namespace AIRE_App.Views;

public partial class RentalListView : ContentPage
{
    private readonly RentalListViewModel viewModel;

    private readonly App app = Application.Current as App;

    public RentalListView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();

        viewModel.LoadRentalData += LoadRentalData;
    }

    private void LoadRentalData()
    {

    }

    private async void OnClicked(Object sender, EventArgs e)
    {
        await DisplayAlert("Log", String.Join(",", viewModel.SearchConditions.QueryItem), "OK");
    }
}
