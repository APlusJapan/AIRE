using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class RentalListGroupViewModel : BaseViewModel
{
    public String Manmei
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String StationInfo
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

    public String KaisouInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ChimeiInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RentalListItemViewModel> Items
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}