using System.Collections.ObjectModel;
using System.Net;
using AIRE_App.Data;

namespace AIRE_App.ViewModels;

public class PrefectureViewModel : BaseViewModel, IQueryAttributable
{
    public RegionType regionType;

    public Action<RegionType> LoadPrefectures;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        var regionName = WebUtility.UrlDecode(query["region"] as String);

        regionType = Enum.Parse<RegionType>(regionName);

        LoadPrefectures(regionType);
    }

    public ObservableCollection<ItemViewModel> Items
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
}