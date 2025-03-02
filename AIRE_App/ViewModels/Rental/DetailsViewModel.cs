using System.Net;

namespace AIRE_App.ViewModels;

public class RentalDetailsViewModel : BaseViewModel, IQueryAttributable
{
    public event Action<String> LoadRentalDetails;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        LoadRentalDetails(WebUtility.UrlDecode(query["rentalId"] as String));
    }

    public String Ekisu
    {
        private get;
        set
        {
            if(Int16.TryParse(value, out _))
            {
                field = value;

                OnPropertyChanged(nameof(hasEki1));
                OnPropertyChanged(nameof(hasEki2));
                OnPropertyChanged(nameof(hasEki3));
            }
        }
    }

    public bool hasEki1
    {
        get
        {
            bool succeed = Int16.TryParse(Ekisu, out short result);

            // ekisu の 0 は「駅を一つ指定」
            return succeed && result >= 0;
        }
    }

    public bool hasEki2
    {
        get
        {
            bool succeed = Int16.TryParse(Ekisu, out short result);

            // ekisu の 1 は「駅を二つ指定」
            return succeed && result >= 1;
        }
    }

    public bool hasEki3
    {
        get
        {
            bool succeed = Int16.TryParse(Ekisu, out short result);

            // ekisu の 2 は「駅を三つ指定」
            return succeed && result >= 2;
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
            OnPropertyChanged();
        }
    }

    public String Eki2Info
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String Eki3Info
    {
        get;
        set
        {
            field = value;
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
}