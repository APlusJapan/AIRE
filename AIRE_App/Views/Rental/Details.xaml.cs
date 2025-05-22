using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;

namespace AIRE_App.Views;

public partial class RentalDetailsView : ContentPage
{
    private Rental rental;

    private CompanyGroup companyGroup;

    private readonly RentalDetailsViewModel viewModel;

    public RentalDetailsView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();

        viewModel.LoadRentalDetails += LoadRentalDetails;
    }

    private void LoadRentalDetails(String rentalId)
    {
        rental = DatabaseService.GetAireDbContext().Rentals.Where(rental => rental.RentalId == rentalId).Single();
        companyGroup = DatabaseService.GetAireDbContext().CompanyGroups.Where(companyGroup => companyGroup.CompanyId == rental.CompanyId).Single();

        viewModel.Manmei = rental.BuildingName;
        viewModel.YachinInfo = GetYachinInfo(rental);
        viewModel.KanrihiInfo = GetKanrihiInfo(rental);
        viewModel.ShikikinInfo = rental.SecurityDeposit;
        viewModel.ReikinInfo = rental.KeyMoney;
        viewModel.MadoriInfo = GetMadoriInfo(rental);
        viewModel.TatemenInfo = $"{rental.ExclusiveArea}m²";
        viewModel.KaidateInfo = GetKaidateInfo(rental);
        viewModel.ChikuInfo = GetChikuInfo(rental);
        viewModel.BukkmokuInfo = rental.BuildingType;
        viewModel.ChimeiSyozaiInfo = rental.Address;
        viewModel.Eki1Info = GetEkiInfo(rental.Transportation1, rental.WalkingDistance1);
        if(!String.IsNullOrWhiteSpace(rental.Transportation2))
        {
            viewModel.Eki2Info = GetEkiInfo(rental.Transportation2, rental.WalkingDistance2);
        }
        if (!String.IsNullOrWhiteSpace(rental.Transportation3))
        {
            viewModel.Eki3Info = GetEkiInfo(rental.Transportation3, rental.WalkingDistance3);
        }
        viewModel.CompanyNameInfo = companyGroup.CompanyName;

        viewModel.Images = [new() { ImageUrl = rental.ExteriorPhoto, ImageInfo = "建物外観" }, new() { ImageUrl = rental.LayoutImage, ImageInfo = "間取り" }];
    }

    private static String GetMoneyInfo(decimal money)
    {
        if (money >= 1e8m)
        {
            decimal manMoney = money % 1e8m / 1e4m;
            decimal okuMoney = money / 1e8m;

            String manString = manMoney.ToString("0.0");
            String okuString = okuMoney.ToString("0");

            return manMoney > 0.1m ?
                String.Format(Constants.OkuManYen, okuString, manString) :
                String.Format(Constants.OkuYen, okuString);
        }

        if (money >= 1e4m)
        {
            decimal manMoney = money / 1e4m;
            String manString = manMoney.ToString("0.0");

            return String.Format(Constants.ManYen, manString);
        }

        String @string = money.ToString("0");
        return String.Format(Constants.Yen, @string);
    }

    private static String GetYachinInfo(Rental rental)
    {
        return GetMoneyInfo(rental.Rent);
    }

    private static String GetKanrihiInfo(Rental rental)
    {
        return rental.ManagementFee > 0 ?
            GetMoneyInfo(rental.ManagementFee):
            "-";
    }
    private static String GetMadoriInfo(Rental rental)
    {
        CodeMaster madotaipu = CodeMasterService.GetCodeMaster("madotaipu", rental.LayoutType);

        // madotaipu の 0 は「ワンルーム」
        return rental.LayoutType == "0" ?
            madotaipu.OptionName :
            $"{rental.LayoutNumber}{madotaipu.OptionName}";
    }

    private static String GetKaidateInfo(Rental rental)
    {
        List<String> kaidateList = [rental.FloorNumber, rental.TotalFloors];

        return String.Join("/", kaidateList);
    }

    private static String GetChikuInfo(Rental rental)
    {
        String chikuInfo;

        int year = DateTime.Now.Year - rental.BuiltYearMonth.Year;
        int month = DateTime.Now.Month - rental.BuiltYearMonth.Month;

        if (month < 0)
        {
            year--;
            month += 12;
        }

        if (rental.NewConstruction)
        {
            chikuInfo = month == 0 ?
                String.Format(Constants.Shinchikunen, year) :
                String.Format(Constants.Shinchikunentsuki, year, month);
        }
        else
        {
            chikuInfo = month == 0 ?
                String.Format(Constants.Chikunen, year) :
                String.Format(Constants.Chikunentsuki, year, month);
        }

        return chikuInfo;
    }

    private static String GetEkiInfo(String transportation, short? walkingDistance)
    {
        return walkingDistance > 0?
            $"{transportation} {String.Format(Constants.Toho, walkingDistance)}":
            transportation;
    }

    private async void OnClicked_Line(Object sender, EventArgs eventArgs)
    {
        await Shell.Current.GoToAsync($"Line", new Dictionary<String, Object>
        {
            { "companyGroup", companyGroup },
            { "staffId", rental.StaffId }
        });
    }
}
