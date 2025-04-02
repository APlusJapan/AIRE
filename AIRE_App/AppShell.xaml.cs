using AIRE_App.Views;

namespace AIRE_App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        RegisterRoute();
    }

    /// <summary>
    /// Shell ナビゲーション
    /// https://learn.microsoft.com/dotnet/maui/fundamentals/shell/navigation
    /// </summary>
    private void RegisterRoute()
    {
        Routing.RegisterRoute("/Region", typeof(RegionView));
        Routing.RegisterRoute("/Prefecture", typeof(PrefectureView));
        Routing.RegisterRoute("/Rental/Search", typeof(RentalSearchView));
        Routing.RegisterRoute("/Rental/List", typeof(RentalListView));
        Routing.RegisterRoute("/Rental/Details", typeof(RentalDetailsView));
    }
}
