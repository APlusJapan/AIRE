using System.Collections.ObjectModel;
using AIRE_App.Data;
using AIRE_App.Services;

namespace AIRE_App.ViewModels;

public class RentalListViewModel : BaseViewModel, IQueryAttributable
{
    public String RawSQL;

    public event Action LoadRentalList;

    public event Func<Task> ExecuteSql;

    public RentalSearchConditions SearchConditions;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        bool sqlModel = Boolean.Parse(query["sqlModel"] as String);

        if (sqlModel)
        {
            RawSQL = query["rawSQL"] as String;

            ExecuteSql();
        }
        else
        {
            SearchConditions = new()
            {
                QueryItem = query["queryItem"] as List<ItemViewModel>,
                YachinMin = query["yachinMin"] as ItemViewModel,
                YachinMax = query["yachinMax"] as ItemViewModel,
                NoKanrihi = (bool)query["noKanrihi"],
                NoReikin = (bool)query["noReikin"],
                NoShikikin = (bool)query["noShikikin"],
                Oneroom = (bool)query["oneroom"],
                Room1k = (bool)query["room1k"],
                Room1dk = (bool)query["room1dk"],
                Room1ldk = (bool)query["room1ldk"],
                Room2k = (bool)query["room2k"],
                Room2dk = (bool)query["room2dk"],
                Room2ldk = (bool)query["room2ldk"],
                Room3k = (bool)query["room3k"],
                Room3dk = (bool)query["room3dk"],
                Room3ldk = (bool)query["room3ldk"],
                Room4k = (bool)query["room4k"],
                Room4dk = (bool)query["room4dk"],
                Room4ldk = (bool)query["room4ldk"],
                Room5k = (bool)query["room5k"],
                Mansion = (bool)query["mansion"],
                Apartment = (bool)query["apartment"],
                DetachedHouse = (bool)query["detachedHouse"],
                Toho = query["toho"] as ItemViewModel,
                MenMin = query["menMin"] as ItemViewModel,
                MenMax = query["menMax"] as ItemViewModel,
                Chikunensu = query["chikunensu"] as ItemViewModel,
                Tyuurin = (bool)query["tyuurin"],
                Btbetu = (bool)query["btbetu"],
                Petka = (bool)query["petka"],
                SecondFloor = (bool)query["secondFloor"],
                Situsentaku = (bool)query["situsentaku"],
                Eakon = (bool)query["eEakon"],
                Outorok = (bool)query["outorok"],
                Furoringu = (bool)query["furoringu"],
                WithFloorPlan = (bool)query["withFloorPlan"],
                WithVideo = (bool)query["withVideo"],
                WithPanorama = (bool)query["withPanorama"],
                NoTeisyaku = (bool)query["noTeisyaku"]
            };

            LoadRentalList();
        }
    }

    public bool MessageReceived
    {
        get
        {
            return AIStatusService.MessageReceived;
        }
        set
        {
            AIStatusService.MessageReceived = value;
            OnPropertyChanged();
        }
    }

    public bool MessageIsExpanded
    {
        get
        {
            return AIStatusService.MessageIsExpanded;
        }
        set
        {
            AIStatusService.MessageIsExpanded = value;
            OnPropertyChanged();
        }
    }

    public String Message
    {
        get
        {
            return AIStatusService.Message;
        }
        set
        {
            AIStatusService.Message = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<String> MessageHistory
    {
        get
        {
            return AIStatusService.MessageHistory;
        }
        set
        {
            AIStatusService.MessageHistory = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RentalListGroupViewModel> Groups
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}