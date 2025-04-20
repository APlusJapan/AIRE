using System.Collections.ObjectModel;
using AIRE_App.Data;
using AIRE_App.Services;

namespace AIRE_App.ViewModels;

public class RentalSearchViewModel : BaseViewModel
{
    public AIStatusViewModel MyAIStatusViewModel
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public List<ItemViewModel> YachinMin { get; }

    public List<ItemViewModel> YachinMax { get; }

    public List<ItemViewModel> Toho { get; }

    public List<ItemViewModel> MenMin { get; }

    public List<ItemViewModel> MenMax { get; }

    public List<ItemViewModel> Chikunensu { get; }

    public RentalSearchViewModel(AIStatusViewModel aiStatusViewModel)
    {
        MyAIStatusViewModel = aiStatusViewModel;

        YachinMin = [.. Options.NoMin, .. Options.Yachin];
        YachinMax = [.. Options.NoMax, .. Options.Yachin];

        Toho = [.. Options.No, .. Options.Toho];

        MenMin = [.. Options.NoMin, .. Options.Men];
        MenMax = [.. Options.NoMax, .. Options.Men];

        Chikunensu = [.. Options.No, .. Options.Chikunensu];
    }

    public int YachinMinIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public int YachinMaxIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool NoKanrihi
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool NoReikin
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool NoShikikin
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Oneroom
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room1k
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room1dk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room1ldk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room2k
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room2dk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room2ldk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room3k
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room3dk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room3ldk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room4k
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room4dk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room4ldk
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Room5k
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Mansion
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Apartment
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool DetachedHouse
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public int TohoIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public int MenMinIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public int MenMaxIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public int ChikunensuIndex
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Tyuurin
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Btbetu
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Petka
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool SecondFloor
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Situsentaku
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Eakon
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Outorok
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool Furoringu
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool WithFloorPlan
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool WithVideo
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool WithPanorama
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool NoTeisyaku
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public bool IsGroupsExpanded
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

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