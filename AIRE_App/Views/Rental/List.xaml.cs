using System.Diagnostics;
using System.Net;
using AIRE_App.Data;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.AspNetCore.Http;

namespace AIRE_App.Views;

public partial class RentalListView : ContentPage
{
    private readonly RentalListViewModel viewModel;

    private readonly App app = Application.Current as App;

    public RentalListView()
    {
        InitializeComponent();

        BindingContext = viewModel = new();

        viewModel.LoadRentalList += LoadRentalList;
    }

    private void LoadRentalList()
    {
        IQueryable<ValidRental> queryable = DatabaseService.GetAireDbContext(str => Trace.WriteLine(str)).ValidRentals;

        bool hasSearchType = Enum.TryParse(app.Session.GetString(nameof(SearchType)), out SearchType searchType);

        if (hasSearchType)
        {
            List<String> queryItemList = [.. viewModel.SearchConditions.QueryItem.Select(item => item.ID)];

            switch (searchType)
            {
                case SearchType.Station:
                    {
                        queryable = queryable.Where(validRental => queryItemList.Contains(validRental.Ekiid1)
                            || queryItemList.Contains(validRental.Ekiid2)
                            || queryItemList.Contains(validRental.Ekiid3));
                        break;
                    }
                case SearchType.Area:
                    {
                        queryable = queryable.Where(validRental => queryItemList.Contains(validRental.AreaId));
                        break;
                    }
            }
        }

        var validRentals = queryable.Select(validRental => new ValidRental()
        {
            RentalId = validRental.RentalId,
            Yachin = validRental.Yachin,
            Kanrihi = validRental.Kanrihi,
            Chimei = validRental.Chimei,
            Syozai = validRental.Syozai,
            Ekiid1 = validRental.Ekiid1,
            Toho1 = validRental.Toho1,
            Ekiid2 = validRental.Ekiid2,
            Toho2 = validRental.Toho2,
            Ekiid3 = validRental.Ekiid3,
            Toho3 = validRental.Toho3,
            Kinkum1 = validRental.Kinkum1,
            Kinkagetu1 = validRental.Kinkagetu1,
            Kinku1 = validRental.Kinku1,
            Kinkum2 = validRental.Kinkum2,
            Kinkagetu2 = validRental.Kinkagetu2,
            Kinku2 = validRental.Kinku2,
            Madoheya = validRental.Madoheya,
            Madotaipu = validRental.Madotaipu,
            Chijou = validRental.Chijou,
            Chika = validRental.Chika,
            SyokaiChika = validRental.SyokaiChika,
            Syokai = validRental.Syokai,
            Chikunen = validRental.Chikunen,
            Chikutsuki = validRental.Chikutsuki,
            Tatemen = validRental.Tatemen,
            Manmei = validRental.Manmei
        }).ToArray();

        viewModel.Groups = [.. validRentals.GroupBy(validRental => new { validRental.Chimei, validRental.Syozai })
            .Select(validRentalGroup => new RentalListGroupViewModel()
            {
                Manmei = validRentalGroup.First().Manmei,
                StationInfo = GetStationInfo(validRentalGroup.First()),
                ChikuInfo = GetChikuInfo(validRentalGroup.First()),
                KaisouInfo = GetKaisouInfo(validRentalGroup.First()),
                ChimeiInfo = validRentalGroup.First().Chimei,
                Items = [.. validRentalGroup.Select(validRentalItem => new RentalListItemViewModel
                    {
                        RentalId = validRentalItem.RentalId,
                        YachinInfo = GetMoneyInfo(validRentalItem.Yachin),
                        KanrihiInfo = GetKanrihiInfo(validRentalItem),
                        ShikikinInfo = GetShikikinInfo(validRentalItem),
                        ReikinInfo = GetReikinInfo(validRentalItem),
                        MadoriInfo = GetMadoriInfo(validRentalItem),
                        TatemenInfo = $"{validRentalItem.Tatemen}m²",
                        SyokaiInfo = GetSyokaiInfo(validRentalItem)
                    })]
            })];
    }

    private static String GetStationInfo(ValidRental validRental)
    {
        (String, short)[] StationInfo = [
            (GetStationInfo(validRental.Ekiid1), validRental.Toho1 ?? Int16.MaxValue),
            (GetStationInfo(validRental.Ekiid2), validRental.Toho2 ?? Int16.MaxValue),
            (GetStationInfo(validRental.Ekiid3), validRental.Toho3 ?? Int16.MaxValue)
        ];

        var stationInfo = StationInfo.MinBy(stationInfo => stationInfo.Item2);

        return stationInfo.Item2 == Int16.MaxValue ?
            $"{stationInfo.Item1}" :
            $"{stationInfo.Item1} {String.Format(Constants.Toho, stationInfo.Item2)}";
    }

    private static String GetStationInfo(String ekiid)
    {
        if (String.IsNullOrWhiteSpace(ekiid))
        {
            return String.Empty;
        }

        Station station = StationService.GetStation(ekiid);
        return $"{station.RailwayCompany}{station.RailwayName}/{station.StationName}";
    }

    private static String GetChikuInfo(ValidRental validRental)
    {
        if (validRental.Chikunen == null)
        {
            return String.Empty;
        }

        int year = DateTime.Now.Year - validRental.Chikunen.Value;

        if (validRental.Chikutsuki > 0)
        {
            if (DateTime.Now.Month < validRental.Chikutsuki.Value) year--;
        }

        return year > 0 ?
            String.Format(Constants.Chikunen, year) :
            Constants.Shinchiku;
    }

    private static String GetKaisouInfo(ValidRental validRental)
    {
        if (validRental.Chijou > 0 && validRental.Chika > 0)
        {
            return String.Format(Constants.ChijouChikaKaisou, validRental.Chijou, validRental.Chika);
        }

        if (validRental.Chika > 0)
        {
            return String.Format(Constants.ChikaKaisou, validRental.Chika);
        }

        if (validRental.Chijou > 0)
        {
            return String.Format(Constants.ChijouKaisou, validRental.Chijou);
        }

        return String.Empty;
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

    private static String GetKanrihiInfo(ValidRental validRental)
    {
        return validRental.Kanrihi > 0 ?
            $"（管理費 {GetMoneyInfo(validRental.Kanrihi.Value)}）" :
            $"（管理費 -）";
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
            madotaipu.OptionName :
            $"{validRental.Madoheya}{madotaipu.OptionName}";
    }

    private static String GetSyokaiInfo(ValidRental validRental)
    {
        if (validRental.SyokaiChika)
        {
            // 所在は地下
            return validRental.Syokai > 0 ?
                String.Format(Constants.ChikaSyokai, validRental.Syokai) :
                Constants.Chika;
        }
        else
        {
            // 所在は地上
            return validRental.Syokai > 0 ?
                String.Format(Constants.ChijouSyokai, validRental.Syokai) :
                Constants.Chijou;
        }
    }

    private async void OnClicked_Back(Object sender, EventArgs eventArgs)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnClicked_Details(Object sender, EventArgs eventArgs)
    {
        if (sender is Button button
            && button.CommandParameter is RentalListItemViewModel rentalListItemViewModel)
        {
            var rentalId = WebUtility.UrlEncode(rentalListItemViewModel.RentalId);
            await Shell.Current.GoToAsync($"/Rental/Details?rentalId={rentalId}");
        }
    }

    private async void OnClicked(Object sender, EventArgs eventArgs)
    {
        await DisplayAlert("Log", String.Join(",", viewModel.SearchConditions.QueryItem), "OK");
    }
}
