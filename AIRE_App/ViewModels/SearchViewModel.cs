using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class SearchViewModel : BaseViewModel
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