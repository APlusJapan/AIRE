using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class GroupViewModel<Item> : ItemViewModel where Item : ItemViewModel
{
    public ObservableCollection<Item> Items
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}