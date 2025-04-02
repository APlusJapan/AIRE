using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;

namespace AIRE_App.Views;

public partial class RentalDetailsView : ContentPage
{
    private ValidRental validRental;

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
        validRental = DatabaseService.GetAireDbContext().ValidRentals.Where(validRental => validRental.RentalId == rentalId).Single();
        companyGroup = DatabaseService.GetAireDbContext().CompanyGroups.Where(companyGroup => companyGroup.CompanyId == validRental.CompanyId).Single();

        viewModel.Manmei = validRental.Manmei;
        viewModel.YachinInfo = GetYachinInfo(validRental);
        viewModel.KanrihiInfo = GetKanrihiInfo(validRental);
        viewModel.ShikikinInfo = GetShikikinInfo(validRental);
        viewModel.ReikinInfo = GetReikinInfo(validRental);
        viewModel.MadoriInfo = GetMadoriInfo(validRental);
        viewModel.TatemenInfo = $"広さ {validRental.Tatemen}m²";
        viewModel.KaidateInfo = GetKaidateInfo(validRental);
        viewModel.ChikuInfo = GetChikuInfo(validRental);
        viewModel.BukkmokuInfo = GetBukkmokuInfo(validRental);
        viewModel.ChimeiSyozaiInfo = GetChimeiSyozaiInfo(validRental);
        viewModel.Ekisu = validRental.Ekisu;
        viewModel.Eki1Info = GetEkiInfo(validRental.Ekiid1, validRental.Toho1);
        viewModel.Eki2Info = GetEkiInfo(validRental.Ekiid2, validRental.Toho2);
        viewModel.Eki3Info = GetEkiInfo(validRental.Ekiid3, validRental.Toho3);
        viewModel.CompanyNameInfo = $"不動産会社 {companyGroup.CompanyName}";
        viewModel.ImageUrl = validRental.Gporder1;
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

    private static String GetYachinInfo(ValidRental validRental)
    {
        return $"家賃 {GetMoneyInfo(validRental.Yachin)}";
    }

    private static String GetKanrihiInfo(ValidRental validRental)
    {
        return validRental.Kanrihi > 0 ?
            $"管理費 {GetMoneyInfo(validRental.Kanrihi.Value)}" :
            $"管理費 -";
    }

    private static String GetShikikinInfo(ValidRental validRental)
    {
        decimal shikikin = 0;

        // kinkum1 の 1 は「保証金」
        // kinkum1 の 7 は「敷金」
        if (validRental.Kinkum1 == "1" || validRental.Kinkum1 == "7")
        {
            switch (validRental.Kinku1)
            {
                // kinku1 の 0 は「万円」
                case "0":
                    {
                        shikikin += validRental.Kinkagetu1 ?? 0;
                        break;
                    }
                // kinku1 の 1 は「ヶ月」
                case "1":
                    {
                        shikikin += (validRental.Kinkagetu1 ?? 0) * validRental.Yachin;
                        break;
                    }
            }
        }

        // kinkum2 の 1 は「保証金」
        // kinkum2 の 7 は「敷金」
        if (validRental.Kinkum2 == "1" || validRental.Kinkum2 == "7")
        {
            switch (validRental.Kinku2)
            {
                // kinku2 の 0 は「万円」
                case "0":
                    {
                        shikikin += validRental.Kinkagetu2 ?? 0;
                        break;
                    }
                // kinku2 の 1 は「ヶ月」
                case "1":
                    {
                        shikikin += (validRental.Kinkagetu2 ?? 0) * validRental.Yachin;
                        break;
                    }
            }
        }

        return shikikin > 0 ?
            $"敷金 {GetMoneyInfo(shikikin)}" :
            $"敷金 -";
    }

    private static String GetReikinInfo(ValidRental validRental)
    {
        decimal reikin = 0;

        // kinkum1 の 3 は「権利金」
        // kinkum1 の 5 は「礼金」
        if (validRental.Kinkum1 == "3" || validRental.Kinkum1 == "5")
        {
            switch (validRental.Kinku1)
            {
                // kinku1 の 0 は「万円」
                case "0":
                    {
                        reikin += validRental.Kinkagetu1 ?? 0;
                        break;
                    }
                // kinku1 の 1 は「ヶ月」
                case "1":
                    {
                        reikin += (validRental.Kinkagetu1 ?? 0) * validRental.Yachin;
                        break;
                    }
            }
        }

        // kinkum2 の 3 は「権利金」
        // kinkum2 の 5 は「礼金」
        if (validRental.Kinkum2 == "3" || validRental.Kinkum2 == "5")
        {
            switch (validRental.Kinku2)
            {
                // kinku2 の 0 は「万円」
                case "0":
                    {
                        reikin += validRental.Kinkagetu2 ?? 0;
                        break;
                    }
                // kinku2 の 1 は「ヶ月」
                case "1":
                    {
                        reikin += (validRental.Kinkagetu2 ?? 0) * validRental.Yachin;
                        break;
                    }
            }
        }

        return reikin > 0 ?
            $"礼金 {GetMoneyInfo(reikin)}" :
            $"礼金 -";
    }

    private static String GetMadoriInfo(ValidRental validRental)
    {
        CodeMaster madotaipu = CodeMasterService.GetCodeMaster("madotaipu", validRental.Madotaipu);

        // madotaipu の 0 は空値
        // madotaipu の 1 は「ワンルーム」
        return validRental.Madotaipu == "0" || validRental.Madotaipu == "1" ?
            $"間取り {madotaipu.OptionName}" :
            $"間取り {validRental.Madoheya}{madotaipu.OptionName}";
    }

    private static String GetKaidateInfo(ValidRental validRental)
    {
        List<String> kaidateList = [];

        if (validRental.SyokaiChika)
        {
            // 所在は地下
            if(validRental.Syokai > 0)
            {
                kaidateList.Add(String.Format(Constants.ChikaSyokai, validRental.Syokai));
            }
            else
            {
                kaidateList.Add(Constants.Chika);
            }
        }
        else
        {
            // 所在は地上
            if (validRental.Syokai > 0)
            {
                kaidateList.Add(String.Format(Constants.ChijouSyokai, validRental.Syokai));
            }
            else
            {
                kaidateList.Add(Constants.Chijou);
            }
        }

        if (validRental.Chijou > 0 && validRental.Chika > 0)
        {
            kaidateList.Add(String.Format(Constants.ChijouChikaKaisou, validRental.Chijou, validRental.Chika));
        }
        else if (validRental.Chika > 0)
        {
            kaidateList.Add(String.Format(Constants.ChikaKaisou, validRental.Chika));
        }
        else if (validRental.Chijou > 0)
        {
            kaidateList.Add(String.Format(Constants.ChijouKaisou, validRental.Chijou));
        }

        return $"階建 {String.Join("/", kaidateList)}";
    }

    private static String GetChikuInfo(ValidRental validRental)
    {
        if (validRental.Chikunen == null)
        {
            return $"築年数 -";
        }

        int year = DateTime.Now.Year - validRental.Chikunen.Value;

        if (validRental.Chikutsuki > 0)
        {
            int month = DateTime.Now.Month - validRental.Chikutsuki.Value;

            if (month < 0)
            {
                year--;
                month += 12;
            }

            return year > 0 ?
                $"築年数 {String.Format(Constants.ChikunenChikutsuki, year, month)}":
                $"築年数 {String.Format(Constants.Chikutsuki, month)}（新築）";
        }

        return $"築年数 {String.Format(Constants.Chikunen, year)}";
    }

    private static String GetBukkmokuInfo(ValidRental validRental)
    {
        if(String.IsNullOrWhiteSpace(validRental.Bukkmoku))
        {
            return "種別 -";
        }

        CodeMaster bukkmoku = CodeMasterService.GetCodeMaster("bukkmoku_rental_residence", validRental.Bukkmoku);

        return $"種別 {bukkmoku.OptionName}";
    }

    private static String GetChimeiSyozaiInfo(ValidRental validRental)
    {
        return $"住所 {validRental.Chimei}-{validRental.Syozai}";
    }

    private static String GetEkiInfo(String ekiid, short? toho)
    {
        if (String.IsNullOrWhiteSpace(ekiid))
        {
            return String.Empty;
        }

        Station station = StationService.GetStation(ekiid);

        return toho > 0?
            $"{station.RailwayCompany}{station.RailwayName}/{station.StationName} {String.Format(Constants.Toho, toho)}":
            $"{station.RailwayCompany}{station.RailwayName}/{station.StationName}";
    }
}
