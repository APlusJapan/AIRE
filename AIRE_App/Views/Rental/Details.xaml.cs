using AIRE_App.ViewModels;

namespace AIRE_App.Views;

public partial class RentalDetailsView : ContentPage
{
    private readonly RentalDetailsViewModel viewModel;

    public RentalDetailsView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();

        viewModel.LoadRentalDetails += LoadRentalDetails;
    }

    private async void LoadRentalDetails(String rentalId)
    {
        await DisplayAlert("Log", rentalId, "OK");
    }
}
