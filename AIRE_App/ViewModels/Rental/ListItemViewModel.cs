namespace AIRE_App.ViewModels;

public class RentalListItemViewModel : BaseViewModel
{
    public String RentalId;

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

    public String SyokaiInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ImageUrl
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}