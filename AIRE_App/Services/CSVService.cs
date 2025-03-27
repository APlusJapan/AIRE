using AIRE_DB.Models;

namespace AIRE_App.Services;

public static class CSVService
{
    private static readonly String rentalSummaryFormat = "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}";

    private static readonly String[] rentalSummaryTitle = ["家賃", "管理費", "敷金", "礼金", "所在地（何丁目まで）", "所在地（何番から）", "駅1の名前", "駅1までの所要時間（バス）", "駅1までの所要時間（徒歩）", "駅1までの所要時間（車）", "駅2の名前", "駅2までの所要時間（バス）", "駅2までの所要時間（徒歩）", "駅2までの所要時間（車）", "駅3の名前", "駅3までの所要時間（バス）", "駅3までの所要時間（徒歩）", "駅3までの所要時間（車）", "物件種目", "構造・材質", "間取り", "階層（地上）", "階層（地下）", "所在階", "築年月", "専有面積", "建物名"];

    public static List<String> RentalSummaryToCSV(IEnumerable<RentalSummary> rentalSummaries)
    {
        List<String> rentalSummaryList = [String.Format(rentalSummaryFormat, rentalSummaryTitle)];

        foreach(var rentalSummary in rentalSummaries)
        {
            rentalSummaryList.Add(String.Format(rentalSummaryFormat,
                rentalSummary.Price, // 家賃
                rentalSummary.ManagementFee, // 管理費
                rentalSummary.SecurityDeposit, // 敷金
                rentalSummary.KeyMoney, // 礼金
                rentalSummary.AddressStreetPart, // 所在地（何丁目まで）
                rentalSummary.AddressNumberPart, // 所在地（何番から）
                rentalSummary.Station1Name, // 駅1の名前
                rentalSummary.Station1BusMin, // 駅1までの所要時間（バス）
                rentalSummary.Station1WalkMin, // 駅1までの所要時間（徒歩）
                rentalSummary.Station1CarTime, // 駅1までの所要時間（車）
                rentalSummary.Station2Name, // 駅2の名前
                rentalSummary.Station2BusMin, // 駅2までの所要時間（バス）
                rentalSummary.Station2WalkMin, // 駅2までの所要時間（徒歩）
                rentalSummary.Station2CarTime, // 駅2までの所要時間（車）
                rentalSummary.Station3Name, // 駅3の名前
                rentalSummary.Station3BusMin, // 駅3までの所要時間（バス）
                rentalSummary.Station3WalkMin, // 駅3までの所要時間（徒歩）
                rentalSummary.Station3CarTime, // 駅3までの所要時間（車）
                rentalSummary.PropertyCategory, // 物件種目
                rentalSummary.StructureMaterial, // 構造・材質
                rentalSummary.FloorPlanType, // 間取り
                rentalSummary.AboveGroundFloors, // 階層（地上）
                rentalSummary.BelowGroundFloors, // 階層（地下）
                rentalSummary.CurrentFloor, // 所在階
                rentalSummary.ConstructionDate, // 築年月
                rentalSummary.ExclusiveArea, // 専有面積
                rentalSummary.BuildingName // 建物名
            ));
        }

        return rentalSummaryList;
    }
}