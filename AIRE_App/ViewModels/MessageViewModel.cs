namespace AIRE_App.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public String Role
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String Text
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public override String ToString()
    {
        return $"{Role}: {Text}";
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

    public String SyokaiInfo
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