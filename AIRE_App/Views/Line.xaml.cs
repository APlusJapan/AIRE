using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;

namespace AIRE_App.Views;

public partial class LineView : ContentPage
{
    private readonly LineViewModel viewModel;

    public LineView()
    {
        InitializeComponent();

        MyWebView.UserAgent = "Desktop";

        BindingContext = viewModel = new();

        viewModel.LoadCompanyMember += LoadCompanyMember;
    }

    private void LoadCompanyMember(CompanyGroup companyGroup, String staffId)
    {
        var companyMember = DatabaseService.GetAireDbContext().CompanyMembers
            .Where(companyMember => companyMember.CompanyId == companyGroup.CompanyId
                && companyMember.StaffId == staffId)
            .Single();

        viewModel.CompanyInfo = companyGroup.CompanyName;

        if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
        {
            if (companyMember.IsBusiness)
            {
                viewModel.URL = String.IsNullOrWhiteSpace(companyMember.RouteId) ?
                    $"https://page.line.me/{companyMember.LineId}" :
                    $"https://page.line.me/{companyMember.LineId}?oat__id={companyMember.RouteId}";
            }
            else
            {
                viewModel.URL = $"https://line.me/R/ti/p/{companyMember.LineId}";
            }

            viewModel.IsMobile = false;
        }

        if (DeviceInfo.Current.Idiom == DeviceIdiom.TV
            || DeviceInfo.Current.Idiom == DeviceIdiom.Watch)
        {
            if (companyMember.IsBusiness)
            {
                viewModel.URL = String.IsNullOrWhiteSpace(companyMember.RouteId) ?
                    $"https://line.me/R/ti/p/@{companyMember.LineId}" :
                    $"https://line.me/R/ti/p/@{companyMember.LineId}?oat__id={companyMember.RouteId}";
            }
            else
            {
                viewModel.URL = $"https://line.me/R/ti/p/{companyMember.LineId}";
            }

            viewModel.IsMobile = false;
            
        }

        if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone
            || DeviceInfo.Current.Idiom == DeviceIdiom.Tablet)
        {
            if (companyMember.IsBusiness)
            {
                viewModel.URL = String.IsNullOrWhiteSpace(companyMember.RouteId) ?
                    $"https://line.me/R/ti/p/@{companyMember.LineId}" :
                    $"https://line.me/R/ti/p/@{companyMember.LineId}?oat__id={companyMember.RouteId}";
            }
            else
            {
                viewModel.URL = $"https://line.me/R/ti/p/{companyMember.LineId}";
            }

            viewModel.IsMobile = true;
        }
    }

    private async void OnClicked_LineCall(Object sender, EventArgs eventArgs)
    {
        await Launcher.OpenAsync(viewModel.URL);
    }
}