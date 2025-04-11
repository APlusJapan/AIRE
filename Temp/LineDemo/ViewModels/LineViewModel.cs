namespace AIRE_App.ViewModels;

public class LineViewModel : BaseViewModel, IQueryAttributable
{
    public event Action<String, String> LoadCompanyMember;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        var companyId = query["companyId"] as String;
        var staffId = query["staffId"] as String;

        LoadCompanyMember(companyId, staffId);
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
