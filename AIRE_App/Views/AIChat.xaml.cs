using AIRE_App.Data;
using AIRE_App.Interfaces;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace AIRE_App.Views;

public partial class AIChatView : ContentPage
{
    private readonly IAIService sqlAIService;

    private readonly AIStatusViewModel aiStatusViewModel;

    public AIChatView(AIStatusViewModel aiStatusViewModel,
        [FromKeyedServices(App.SqlAIServiceKey)] IAIService sqlAIService)
    {
        InitializeComponent();

        this.sqlAIService = sqlAIService;

        BindingContext = this.aiStatusViewModel = aiStatusViewModel;
    }

    private async Task ExecuteSql(String rawSQL)
    {
        var random = new Random();

        var rentalSummaries = DatabaseService.GetAireDbContext().RentalSummaries.FromSqlRaw(rawSQL).ToArray();

        var randomRentalSummaryArray = rentalSummaries.OrderBy(rentalSummary => random.Next()).Take(3).ToArray();

        foreach(var randomRentalSummary in randomRentalSummaryArray)
        {
            MessageViewModel rentalMessageViewModel = new()
            {
                Role = "__rental",
                Text = randomRentalSummary.RentalId,
                Manmei = randomRentalSummary.BuildingName,
                YachinInfo = GetMoneyInfo(randomRentalSummary.Price),
                KanrihiInfo = GetKanrihiInfo(randomRentalSummary),
                ShikikinInfo = GetShikikinInfo(randomRentalSummary),
                ReikinInfo = GetReikinInfo(randomRentalSummary),
                MadoriInfo = randomRentalSummary.FloorPlanType,
                TatemenInfo = $"{randomRentalSummary.ExclusiveArea}m²",
                SyokaiInfo = GetSyokaiInfo(randomRentalSummary),
                StationInfo = GetStationInfo(randomRentalSummary),
                ChikuInfo = GetChikuInfo(randomRentalSummary),
                KaisouInfo = GetKaisouInfo(randomRentalSummary),
                ChimeiInfo = randomRentalSummary.Address
            };

            if (!String.IsNullOrWhiteSpace(randomRentalSummary.ExteriorPhoto))
            {
                rentalMessageViewModel.ImageUrl = randomRentalSummary.ExteriorPhoto;
            }
            else if (!String.IsNullOrWhiteSpace(randomRentalSummary.FloorPlanImage))
            {
                rentalMessageViewModel.ImageUrl = randomRentalSummary.FloorPlanImage;
            }
            else
            {
                rentalMessageViewModel.ImageUrl = String.Empty;
            }

            aiStatusViewModel.MessageHistory.Add(rentalMessageViewModel);

            JSONService.AppendMessage(rentalMessageViewModel);
        }

        await Task.CompletedTask;
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

    private static String GetShikikinInfo(RentalSummary rentalSummary)
    {
        return rentalSummary.SecurityDeposit > 0 ?
            $"敷金 {GetMoneyInfo(rentalSummary.SecurityDeposit)}" :
            $"敷金 -";
    }

    private static String GetReikinInfo(RentalSummary rentalSummary)
    {
        return rentalSummary.KeyMoney > 0 ?
            $"礼金 {GetMoneyInfo(rentalSummary.KeyMoney)}" :
            $"礼金 -";
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

        }, ExecuteSql);
    }
}