namespace AIRE_App.ViewModels;

public class ItemViewModel : BaseViewModel
{
    public String Name
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}