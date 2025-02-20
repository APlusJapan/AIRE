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
        Routing.RegisterRoute("Search", typeof(SearchView));
    }
}
