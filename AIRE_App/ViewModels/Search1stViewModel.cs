using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class Search1stViewModel : BaseViewModel
{
    public ObservableCollection<GroupViewModel<GroupViewModel<ItemViewModel>>> Groups
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}