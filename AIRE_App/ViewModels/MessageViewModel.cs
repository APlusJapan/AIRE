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
}