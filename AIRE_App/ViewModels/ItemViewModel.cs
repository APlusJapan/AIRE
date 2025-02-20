namespace AIRE_App.ViewModels;

public class ItemViewModel : BaseViewModel
{
    protected bool isChecked;

    public Action<bool> ParentItemCheck;

    public virtual bool IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked != value)
            {
                isChecked = value;

                ParentItemCheck?.Invoke(value);

                OnPropertyChanged();
            }
        }
    }

    public String ID
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

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