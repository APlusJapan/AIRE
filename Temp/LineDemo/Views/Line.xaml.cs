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

    private void LoadCompanyMember(String companyId, String staffId)
    {
        var CompanyGroup = new CompanyGroup()
        {
            CompanyId = companyId
        };

        var companyMember = new CompanyMember()
        {
            CompanyId = companyId,
            StaffId = staffId,
            LineId = "745jmues",
            RouteId = "5215546",
            IsBusiness = true
        };

        switch (companyId)
        {
            case "A":
                {
                    companyMember.IsBusiness = true;
                    companyMember.LineId = "745jmues";
                    CompanyGroup.CompanyId = "ポケモン株式会社";
                    break;
                }
            case "B":
                {
                    companyMember.IsBusiness = true;
                    companyMember.LineId = "938styyl";
                    companyMember.RouteId = "5215546";
                    CompanyGroup.CompanyId = "A-Plus株式会社";
                    break;
                }
            case "C":
                {
                    companyMember.IsBusiness = false;
                    companyMember.LineId = "";
                    CompanyGroup.CompanyId = "A-Plus株式会社";
                    break;
                }
        }

        viewModel.CompanyInfo = CompanyGroup.CompanyId;

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