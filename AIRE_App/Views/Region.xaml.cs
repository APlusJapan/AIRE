using System.Net;
using AIRE_App.Data;

namespace AIRE_App.Views;

public partial class RegionView : ContentPage
{
    public RegionView()
    {
        InitializeComponent();
    }

    private async void OnClicked_Prefecture(Object sender, EventArgs eventArgs)
    {
        if (sender is ImageButton button
           && button.CommandParameter is RegionType regionType)
        {
            var regionName = WebUtility.UrlEncode(regionType.ToString());
            await Shell.Current.GoToAsync($"Prefecture?region={regionName}");
        }
    }
}