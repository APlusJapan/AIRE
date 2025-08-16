using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using System.Net;

namespace AIRE_App.DataTemplates;

public partial class RentalMessageTemplate : ContentView
{
    private readonly App app = Application.Current as App;

    public RentalMessageTemplate()
    {
        InitializeComponent();
    }

    private async void OnClicked_Details(Object sender, EventArgs eventArgs)
    {
        if (sender is Button button
            && button.CommandParameter is MessageViewModel rentalMessageViewModel)
        {
            var rentalId = WebUtility.UrlEncode(rentalMessageViewModel.Text);
            var responseId = WebUtility.UrlEncode(app.Handler.MauiContext.Services.GetKeyedService<IAIService>(App.SqlAIServiceKey).GetID());
            await Shell.Current.GoToAsync($"Rental/Details?rentalId={rentalId}&responseId={responseId}");
        }
    }
}