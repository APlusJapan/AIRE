using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class AIStatusViewModel : BaseViewModel
{
    public bool MessageReceived
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    } = true;

    public String Message
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    } = String.Empty;

    public bool MessageIsExpanded
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    } = false;

    public ObservableCollection<MessageViewModel> MessageHistory
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    } = [];
}