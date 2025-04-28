namespace AIRE_App.ViewModels;

public class ImageViewModel : BaseViewModel
{
    public String ImageUrl
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public String ImageInfo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}