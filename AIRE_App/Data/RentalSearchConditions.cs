using AIRE_App.ViewModels;

namespace AIRE_App.Data;

public class RentalSearchConditions
{
    public SearchType MySearchType { get; init; }

    public List<ItemViewModel> QueryItem { get; init; }

    public ItemViewModel YachinMin { get; init; }

    public ItemViewModel YachinMax { get; init; }

    public bool NoKanrihi { get; init; }

    public bool NoReikin { get; init; }

    public bool NoShikikin { get; init; }

    public bool Oneroom { get; init; }

    public bool Room1k { get; init; }

    public bool Room1dk { get; init; }

    public bool Room1ldk { get; init; }

    public bool Room2k { get; init; }

    public bool Room2dk { get; init; }

    public bool Room2ldk { get; init; }

    public bool Room3k { get; init; }

    public bool Room3dk { get; init; }

    public bool Room3ldk { get; init; }

    public bool Room4k { get; init; }

    public bool Room4dk { get; init; }

    public bool Room4ldk { get; init; }

    public bool Room5k { get; init; }

    public bool Mansion { get; init; }

    public bool Apartment { get; init; }

    public bool DetachedHouse { get; init; }

    public ItemViewModel Toho { get; init; }

    public ItemViewModel MenMin { get; init; }

    public ItemViewModel MenMax { get; init; }

    public ItemViewModel Chikunensu { get; init; }

    public bool Tyuurin { get; init; }

    public bool Btbetu { get; init; }

    public bool Petka { get; init; }

    public bool SecondFloor { get; init; }

    public bool Situsentaku { get; init; }

    public bool Eakon { get; init; }

    public bool Outorok { get; init; }

    public bool Furoringu { get; init; }

    public bool WithVideo { get; init; }

    public bool WithPanorama { get; init; }

    public bool WithFloorPlan { get; init; }

    public bool NoTeisyaku { get; init; }
}