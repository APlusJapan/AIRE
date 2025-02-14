using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AIRE_App.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] String propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}