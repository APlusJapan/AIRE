using System.Net;
using AIRE_App.Data;
using AIRE_App.Interfaces;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace AIRE_App.Views;

public partial class RentalListView : ContentPage
{
    private readonly IAIService sqlAIService;

    private readonly IAIService summaryAIService;

    private readonly RentalListViewModel viewModel;

    private readonly AIStatusViewModel aiStatusViewModel;

    public RentalListView(AIStatusViewModel aiStatusViewModel,
        [FromKeyedServices(App.SqlAIServiceKey)] IAIService sqlAIService,
        [FromKeyedServices(App.SummaryAIServiceKey)] IAIService summaryAIService)
    {
        InitializeComponent();

        this.sqlAIService = sqlAIService;

        this.summaryAIService = summaryAIService;

        this.aiStatusViewModel = aiStatusViewModel;

        BindingContext = viewModel = new(aiStatusViewModel);

        viewModel.ExecuteSql += ExecuteSql;

        viewModel.LoadRentalList += LoadRentalList;
    }

    private async Task GoToList(String rawSQL)
    {
        await Shell.Current.GoToAsync("Rental/List?sqlModel=True", new Dictionary<String, Object>
        {
            { "rawSQL", rawSQL }
        });
    }

    private async Task ExecuteSql()
    {
        // await DisplayAlert("Log", viewModel.RawSQL, "OK");

        var rentalSummaries = DatabaseService.GetAireDbContext().RentalSummaries.FromSqlRaw(viewModel.RawSQL).ToArray();

        viewModel.Groups = [.. rentalSummaries.GroupBy(rentalSummary => new { rentalSummary.AddressStreetPart, rentalSummary.AddressNumberPart })
            .Select(rentalSummaryGroup => new RentalListGroupViewModel()
            {
                Manmei = rentalSummaryGroup.First().BuildingName,
                StationInfo = GetStationInfo(rentalSummaryGroup.First()),
                ChikuInfo = GetChikuInfo(rentalSummaryGroup.First()),
                KaisouInfo = GetKaisouInfo(rentalSummaryGroup.First()),
                ChimeiInfo = rentalSummaryGroup.Key.AddressStreetPart,
                ImageUrl = rentalSummaryGroup.First().ExteriorPhoto,
                Items = [.. rentalSummaryGroup.Select(rentalSummaryItem => new RentalListItemViewModel()
                {
                    RentalId = rentalSummaryItem.RentalId,
                    YachinInfo = GetMoneyInfo(rentalSummaryItem.Price),
                    KanrihiInfo = GetKanrihiInfo(rentalSummaryItem),
                    ShikikinInfo = GetShikikinInfo(rentalSummaryItem),
                    ReikinInfo = GetReikinInfo(rentalSummaryItem),
                    MadoriInfo = rentalSummaryItem.FloorPlanType,
                    TatemenInfo = $"{rentalSummaryItem.ExclusiveArea}m²",
                    SyokaiInfo = GetSyokaiInfo(rentalSummaryItem),
                    ImageUrl = rentalSummaryItem.FloorPlanImage
                })]
            })];

        aiStatusViewModel.MessageReceived = false;

        await summaryAIService.ProcessRecommendAsync(CSVService.RentalSummaryToCSV(rentalSummaries.Where(rentalSummary => rentalSummary.Recommend)), response =>
        {
            aiStatusViewModel.AssistantMessage = response.Text;

            aiStatusViewModel.MessageHistory.Add(response);

            JSONService.AppendMessage(response);

            aiStatusViewModel.MessageReceived = true;

            return Task.CompletedTask;

        });
    }

    private void LoadRentalList()
    {
        IQueryable<Rental> queryable = DatabaseService.GetAireDbContext().Rentals;

        List<String> queryItemList = [.. viewModel.SearchConditions.QueryItem.Select(item => item.Name)];

        switch (viewModel.SearchConditions.MySearchType)
        {
            case SearchType.Station:
                {
                    queryable = queryable.Where(rental =>
                        queryItemList.Any(name => rental.Transportation1.Contains(name))
                        || queryItemList.Any(name => rental.Transportation2.Contains(name))
                        || queryItemList.Any(name => rental.Transportation3.Contains(name)));
                    break;
                }
            case SearchType.Area:
                {
                    queryable = queryable.Where(rental =>
                        queryItemList.Any(name => rental.Address.Contains(name)));
                    break;
                }
        }

        // 管理費・共益費込み
        bool noKanrihi = viewModel.SearchConditions.NoKanrihi;
        // 賃料下限
        int yachinMin = Int32.Parse(viewModel.SearchConditions.YachinMin.ID);
        // 賃料上限
        int yachinMax = Int32.Parse(viewModel.SearchConditions.YachinMax.ID);

        // 下限のみ
        if (yachinMin != -1 && yachinMax == -1)
        {
            if (noKanrihi)
            {
                queryable = queryable.Where(rental =>
                    yachinMin <= rental.Rent + rental.ManagementFee + rental.MaintenanceFee);
            }
            else
            {
                queryable = queryable.Where(rental =>
                    yachinMin <= rental.Rent);
            }
        }

        // 上限のみ
        if (yachinMin == -1 && yachinMax != -1)
        {
            if (noKanrihi)
            {
                queryable = queryable.Where(rental =>
                    rental.Rent + rental.ManagementFee + rental.MaintenanceFee <= yachinMax);
            }
            else
            {
                queryable = queryable.Where(rental =>
                    rental.Rent <= yachinMax);
            }
        }

        // 両方あり
        if (yachinMin != -1 && yachinMax != -1)
        {
            if (noKanrihi)
            {
                queryable = queryable.Where(rental =>
                    yachinMin <= rental.Rent + rental.ManagementFee + rental.MaintenanceFee
                    && rental.Rent + rental.ManagementFee + rental.MaintenanceFee <= yachinMax);
            }
            else
            {
                queryable = queryable.Where(rental =>
                    yachinMin <= rental.Rent
                    && rental.Rent <= yachinMax);
            }
        }

        // 礼金なし
        if (viewModel.SearchConditions.NoReikin)
        {
            queryable = queryable.Where(rental => rental.KeyMoney == "-");
        }

        // 敷金・保証金なし
        if (viewModel.SearchConditions.NoShikikin)
        {
            queryable = queryable.Where(rental =>
                rental.SecurityDeposit == "-"
                && rental.GuaranteeMoney == "-");
        }

        // ワンルーム
        bool oneroom = viewModel.SearchConditions.Oneroom;
        // 1K
        bool room1k = viewModel.SearchConditions.Room1k;
        // 1DK
        bool room1dk = viewModel.SearchConditions.Room1dk;
        // 1LDK
        bool room1ldk = viewModel.SearchConditions.Room1ldk;
        // 2K
        bool room2k = viewModel.SearchConditions.Room2k;
        // 2DK
        bool room2dk = viewModel.SearchConditions.Room2dk;
        // 2LDK
        bool room2ldk = viewModel.SearchConditions.Room2ldk;
        // 3K
        bool room3k = viewModel.SearchConditions.Room3k;
        // 3DK
        bool room3dk = viewModel.SearchConditions.Room3dk;
        // 3LDK
        bool room3ldk = viewModel.SearchConditions.Room3ldk;
        // 4K
        bool room4k = viewModel.SearchConditions.Room4k;
        // 4DK
        bool room4dk = viewModel.SearchConditions.Room4dk;
        // 4LDK
        bool room4ldk = viewModel.SearchConditions.Room4ldk;
        // 5k以上
        bool room5k = viewModel.SearchConditions.Room5k;

        if (oneroom || room1k || room1dk || room1ldk || room2k || room2dk || room2ldk
            || room3k || room3dk || room3ldk || room4k || room4dk || room4ldk || room5k)
        {
            queryable = queryable.Where(rental =>
                oneroom && rental.LayoutType == "0"
                || room1k && rental.LayoutNumber == 1 && rental.LayoutType == "1"
                || room1k && rental.LayoutNumber == 1 && rental.LayoutType == "9"
                || room1dk && rental.LayoutNumber == 1 && rental.LayoutType == "3"
                || room1dk && rental.LayoutNumber == 1 && rental.LayoutType == "11"
                || room1ldk && rental.LayoutNumber == 1 && rental.LayoutType == "7"
                || room1ldk && rental.LayoutNumber == 1 && rental.LayoutType == "15"
                || room2k && rental.LayoutNumber == 2 && rental.LayoutType == "1"
                || room2k && rental.LayoutNumber == 2 && rental.LayoutType == "9"
                || room2dk && rental.LayoutNumber == 2 && rental.LayoutType == "3"
                || room2dk && rental.LayoutNumber == 2 && rental.LayoutType == "11"
                || room2ldk && rental.LayoutNumber == 2 && rental.LayoutType == "7"
                || room2ldk && rental.LayoutNumber == 2 && rental.LayoutType == "15"
                || room3k && rental.LayoutNumber == 3 && rental.LayoutType == "1"
                || room3k && rental.LayoutNumber == 3 && rental.LayoutType == "9"
                || room3dk && rental.LayoutNumber == 3 && rental.LayoutType == "3"
                || room3dk && rental.LayoutNumber == 3 && rental.LayoutType == "11"
                || room3ldk && rental.LayoutNumber == 3 && rental.LayoutType == "7"
                || room3ldk && rental.LayoutNumber == 3 && rental.LayoutType == "15"
                || room4k && rental.LayoutNumber == 4 && rental.LayoutType == "1"
                || room4k && rental.LayoutNumber == 4 && rental.LayoutType == "9"
                || room4dk && rental.LayoutNumber == 4 && rental.LayoutType == "3"
                || room4dk && rental.LayoutNumber == 4 && rental.LayoutType == "11"
                || room4ldk && rental.LayoutNumber == 4 && rental.LayoutType == "7"
                || room4ldk && rental.LayoutNumber == 4 && rental.LayoutType == "15"
                || room5k && rental.LayoutNumber >= 5);
        }

        // マンション
        bool mansion = viewModel.SearchConditions.Mansion;
        // アパート
        bool apartment = viewModel.SearchConditions.Apartment;
        // 一戸建て・その他
        bool detachedHouse = viewModel.SearchConditions.DetachedHouse;

        if (mansion || apartment || detachedHouse)
        {
            queryable = queryable.Where(rental =>
                mansion && rental.BuildingType.Contains("マンション")
                || apartment && rental.BuildingType.Contains("アパート")
                || detachedHouse && !rental.BuildingType.Contains("マンション") && !rental.BuildingType.Contains("アパート"));
        }

        // 駅徒歩
        int toho = Int32.Parse(viewModel.SearchConditions.Toho.ID);

        if (toho != -1)
        {
            queryable = queryable.Where(rental =>
                rental.WalkingDistance1 <= toho
                || rental.WalkingDistance2 <= toho
                || rental.WalkingDistance3 <= toho);
        }

        // 面積下限
        int menMin = Int32.Parse(viewModel.SearchConditions.MenMin.ID);
        // 面積上限
        int menMax = Int32.Parse(viewModel.SearchConditions.MenMax.ID);

        // 下限のみ
        if (menMin != -1 && menMax == -1)
        {
            queryable = queryable.Where(rental =>
                menMin <= rental.ExclusiveArea);
        }

        // 上限のみ
        if (menMin == -1 && menMax != -1)
        {
            queryable = queryable.Where(rental =>
                rental.ExclusiveArea <= menMax);
        }

        // 両方あり
        if (menMin != -1 && menMax != -1)
        {
            queryable = queryable.Where(rental =>
                menMin <= rental.ExclusiveArea
                && rental.ExclusiveArea <= menMax);
        }

        // 築年数
        int chikunensu = Int32.Parse(viewModel.SearchConditions.Chikunensu.ID);

        if (chikunensu == 0)
        {
            // 新築
            queryable = queryable.Where(rental =>
                rental.NewConstruction == true);
        }

        if (chikunensu > 0)
        {
            // 何年前
            var dateOnly = DateOnly.FromDateTime(DateTime.Today.AddYears(-chikunensu));

            queryable = queryable.Where(rental =>
                dateOnly <= rental.BuiltYearMonth);
        }

        // 駐車場あり
        bool tyuurin = viewModel.SearchConditions.Tyuurin;

        if(tyuurin)
        {
            queryable = queryable.Where(rental =>
                rental.Parking != "-" && !rental.Parking.Contains("無"));
        }

        // バス・トイレ別
        bool btbetu = viewModel.SearchConditions.Btbetu;

        if(btbetu)
        {
            queryable = queryable.Where(rental => EF.Functions.Like(rental.FreeKeyword, "%バス%トイレ別%"));
        }

        // ペット相談
        bool petka = viewModel.SearchConditions.Petka;

        if(petka)
        {
            queryable = queryable.Where(rental => rental.RentalConditions.Contains("ペット相談"));
        }

        // 2階以上住戸
        bool secondFloor = viewModel.SearchConditions.SecondFloor;

        if(secondFloor)
        {
            queryable = queryable.Where(rental =>
                !rental.FloorNumber.StartsWith("1階")
                && !rental.FloorNumber.StartsWith("地下"));
        }

        // 室内洗濯機置場
        bool situsentaku = viewModel.SearchConditions.Situsentaku;

        if(situsentaku)
        {
            queryable = queryable.Where(rental => EF.Functions.Like(rental.FreeKeyword, "%洗濯%置%"));
        }

        // エアコン付
        bool eakon = viewModel.SearchConditions.Eakon;

        if (eakon)
        {
            queryable = queryable.Where(rental => rental.FreeKeyword.Contains("エアコン"));
        }

        // オートロック
        bool outorok = viewModel.SearchConditions.Outorok;

        if (outorok)
        {
            queryable = queryable.Where(rental => rental.FreeKeyword.Contains("オートロック"));
        }

        // フローリング
        bool furoringu = viewModel.SearchConditions.Furoringu;

        if (furoringu)
        {
            queryable = queryable.Where(rental => rental.FreeKeyword.Contains("フローリング"));
        }

        // 間取り図付
        bool withFloorPlan = viewModel.SearchConditions.WithFloorPlan;

        if (withFloorPlan)
        {
            queryable = queryable.Where(rental => !String.IsNullOrWhiteSpace(rental.LayoutImage));
        }

        // 定期借家を含まない
        bool noTeisyaku = viewModel.SearchConditions.NoTeisyaku;

        if (noTeisyaku)
        {
            queryable = queryable.Where(rental =>
                !rental.RentalConditions.Contains("定期借家")
                && !rental.ContractPeriod.StartsWith("定期借家"));
        }

        var rentals = queryable.ToArray();

        viewModel.Groups = [.. rentals.GroupBy(rental => new { rental.BuildingName, rental.Address })
            .Select(rentalGroup => new RentalListGroupViewModel()
            {
                Manmei = rentalGroup.Key.BuildingName,
                StationInfo = GetStationInfo(rentalGroup.First()),
                ChikuInfo = GetChikuInfo(rentalGroup.First()),
                KaisouInfo = rentalGroup.First().TotalFloors,
                ChimeiInfo = rentalGroup.Key.Address,
                ImageUrl = rentalGroup.First().ExteriorPhoto,
                Items = [.. rentalGroup.Select(rentalItem => new RentalListItemViewModel
                {
                    RentalId = rentalItem.RentalId,
                    YachinInfo = GetMoneyInfo(rentalItem.Rent),
                    KanrihiInfo = GetKanrihiInfo(rentalItem),
                    ShikikinInfo = GetShikikinInfo(rentalItem),
                    ReikinInfo = GetReikinInfo(rentalItem),
                    MadoriInfo = GetMadoriInfo(rentalItem),
                    TatemenInfo = $"{rentalItem.ExclusiveArea}m²",
                    SyokaiInfo = rentalItem.FloorNumber,
                    ImageUrl = rentalItem.LayoutImage
                })]
            })];
    }

    private static String GetStationInfo(RentalSummary rentalSummary)
    {
        (String, short)[] StationInfo = [
            (rentalSummary.Station1Name, rentalSummary.Station1WalkMin ?? Int16.MaxValue),
            (rentalSummary.Station2Name, rentalSummary.Station2WalkMin ?? Int16.MaxValue),
            (rentalSummary.Station3Name, rentalSummary.Station3WalkMin ?? Int16.MaxValue)
        ];

        var stationInfo = StationInfo.MinBy(stationInfo => stationInfo.Item2);

        return stationInfo.Item2 == Int16.MaxValue ?
            $"{stationInfo.Item1}" :
            $"{stationInfo.Item1} {String.Format(Constants.Toho, stationInfo.Item2)}";
    }

    private static String GetStationInfo(Rental rental)
    {
        (String, short)[] StationInfo = [
            (rental.Transportation1, rental.WalkingDistance1),
            (rental.Transportation2, rental.WalkingDistance2 ?? Int16.MaxValue),
            (rental.Transportation3, rental.WalkingDistance3 ?? Int16.MaxValue)
        ];

        var stationInfo = StationInfo.MinBy(stationInfo => stationInfo.Item2);

        return stationInfo.Item2 == Int16.MaxValue ?
            $"{stationInfo.Item1}" :
            $"{stationInfo.Item1} {String.Format(Constants.Toho, stationInfo.Item2)}";
    }
    private static String GetChikuInfo(RentalSummary rentalSummary)
    {
        int year = DateTime.Now.Year - rentalSummary.ConstructionDate.Year;
        int month = DateTime.Now.Month - rentalSummary.ConstructionDate.Month;

        if (month < 0)
        {
            year--;
            month += 12;
        }

        return month == 0 ?
            String.Format(Constants.Chikunen, year) :
            String.Format(Constants.Chikunentsuki, year, month);
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

        if(rental.NewConstruction)
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

    private static String GetKaisouInfo(RentalSummary rentalSummary)
    {
        if (rentalSummary.AboveGroundFloors > 0 && rentalSummary.BelowGroundFloors > 0)
        {
            return String.Format(Constants.ChijouChikaKaisou, rentalSummary.AboveGroundFloors, rentalSummary.BelowGroundFloors);
        }

        if (rentalSummary.BelowGroundFloors > 0)
        {
            return String.Format(Constants.ChikaKaisou, rentalSummary.BelowGroundFloors);
        }

        if (rentalSummary.AboveGroundFloors > 0)
        {
            return String.Format(Constants.ChijouKaisou, rentalSummary.AboveGroundFloors);
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

    private static String GetKanrihiInfo(RentalSummary rentalSummary)
    {
        return rentalSummary.ManagementFee > 0 ?
            $"（管理費 {GetMoneyInfo(rentalSummary.ManagementFee.Value)}）" :
            $"（管理費 -）";
    }

    private static String GetKanrihiInfo(Rental rental)
    {
        return rental.ManagementFee > 0 ?
            $"（管理費 {GetMoneyInfo(rental.ManagementFee)}）" :
            $"（管理費 -）";
    }

    private static String GetShikikinInfo(RentalSummary rentalSummary)
    {
        return rentalSummary.SecurityDeposit > 0 ?
            $"敷金 {GetMoneyInfo(rentalSummary.SecurityDeposit)}" :
            $"敷金 -";
    }

    private static String GetShikikinInfo(Rental rental)
    {
        return $"敷金 {rental.SecurityDeposit}";
    }

    private static String GetReikinInfo(RentalSummary rentalSummary)
    {
        return rentalSummary.KeyMoney > 0 ?
            $"礼金 {GetMoneyInfo(rentalSummary.KeyMoney)}" :
            $"礼金 -";
    }

    private static String GetReikinInfo(Rental rental)
    {
        return $"礼金 {rental.KeyMoney}";
    }

    private static String GetMadoriInfo(Rental rental)
    {
        CodeMaster madotaipu = CodeMasterService.GetCodeMaster("madotaipu", rental.LayoutType);

        // madotaipu の 0 は「ワンルーム」
        return rental.LayoutType == "0" ?
            madotaipu.OptionName :
            $"{rental.LayoutNumber}{madotaipu.OptionName}";
    }

    private static String GetSyokaiInfo(RentalSummary rentalSummary)
    {
        if (rentalSummary.CurrentFloor < 0)
        {
            // 所在は地下
            return String.Format(Constants.ChikaSyokai, -rentalSummary.CurrentFloor);
        }
        else
        {
            // 所在は地上
            return String.Format(Constants.ChijouSyokai, rentalSummary.CurrentFloor);
        }
    }

    private void OnClicked_ExpandMessage(Object sender, EventArgs eventArgs)
    {
        aiStatusViewModel.MessageIsExpanded = !aiStatusViewModel.MessageIsExpanded;
    }

    private async void OnClicked_PostMessage(Object sender, EventArgs eventArgs)
    {
        if (String.IsNullOrWhiteSpace(aiStatusViewModel.UserMessage))
        {
            return;
        }

        var message = aiStatusViewModel.UserMessage;

        aiStatusViewModel.UserMessage = String.Empty;

        var messageViewModel = new MessageViewModel()
        {
            Role = "user",
            Text = message
        };

        aiStatusViewModel.MessageHistory.Add(messageViewModel);

        JSONService.AppendMessage(messageViewModel);

        aiStatusViewModel.MessageReceived = false;

        await sqlAIService.PostChatMessageAsync(message, response =>
        {
            aiStatusViewModel.AssistantMessage = response.Text;

            aiStatusViewModel.MessageHistory.Add(response);

            JSONService.AppendMessage(response);

            aiStatusViewModel.MessageReceived = true;

            return Task.CompletedTask;

        }, GoToList);
    }

    private async void OnClicked_Details(Object sender, EventArgs eventArgs)
    {
        if (sender is Button button
            && button.CommandParameter is RentalListItemViewModel rentalListItemViewModel)
        {
            var rentalId = WebUtility.UrlEncode(rentalListItemViewModel.RentalId);
            await Shell.Current.GoToAsync($"Rental/Details?rentalId={rentalId}");
        }
    }
}
