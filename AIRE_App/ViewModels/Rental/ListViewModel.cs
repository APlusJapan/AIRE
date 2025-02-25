using AIRE_App.Data;

namespace AIRE_App.ViewModels;

public class RentalListViewModel : BaseViewModel, IQueryAttributable
{
    public event Action LoadRentalData;

    public RentalSearchConditions SearchConditions;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
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

        LoadRentalData();
    }
}