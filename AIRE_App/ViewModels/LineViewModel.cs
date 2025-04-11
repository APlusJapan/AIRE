using AIRE_DB.Models;

namespace AIRE_App.ViewModels;

public class LineViewModel : BaseViewModel, IQueryAttributable
{
    public event Action<CompanyGroup, String> LoadCompanyMember;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        var companyGroup = query["companyGroup"] as CompanyGroup;
        var staffId = query["staffId"] as String;

        LoadCompanyMember(companyGroup, staffId);
    }

    public bool IsMobile
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String URL
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String CompanyInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}
