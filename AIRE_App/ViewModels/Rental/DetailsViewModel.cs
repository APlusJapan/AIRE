using System.Net;

namespace AIRE_App.ViewModels;

public class RentalDetailsViewModel : BaseViewModel, IQueryAttributable
{
    public event Action<String> LoadRentalDetails;

    public void ApplyQueryAttributes(IDictionary<String, Object> query)
    {
        LoadRentalDetails(WebUtility.UrlDecode(query["rentalId"] as String));
    }
}