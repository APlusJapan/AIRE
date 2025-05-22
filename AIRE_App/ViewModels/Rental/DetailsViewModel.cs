using System.Collections.ObjectModel;
using System.Net;

namespace AIRE_App.ViewModels;

public class RentalDetailsViewModel : BaseViewModel, IQueryAttributable
{
    public event Action<String> LoadRentalDetails;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        LoadRentalDetails(WebUtility.UrlDecode(query["rentalId"] as String));
    }

    public bool hasEki1
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool hasEki2
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool hasEki3
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String Manmei
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String YachinInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String KanrihiInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ShikikinInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ReikinInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String MadoriInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String TatemenInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String KaidateInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ChikuInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String BukkmokuInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ChimeiSyozaiInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String Eki1Info
    {
        get;
        set
        {
            field = value;
            hasEki1 = true;
            OnPropertyChanged();
        }
    }

    public String Eki2Info
    {
        get;
        set
        {
            field = value;
            hasEki2 = true;
            OnPropertyChanged();
        }
    }

    public String Eki3Info
    {
        get;
        set
        {
            field = value;
            hasEki3 = true;
            OnPropertyChanged();
        }
    }

    public String CompanyNameInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<ImageViewModel> Images
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}