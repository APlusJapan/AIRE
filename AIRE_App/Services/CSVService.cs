using AIRE_DB.Models;

namespace AIRE_App.Services;

public static class CSVService
{
    private static readonly String rentalSummaryFormat = "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}";

    private static readonly String rentalDetailsFormat = "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}";

    private static readonly String[] rentalSummaryTitle = ["家賃", "管理費", "敷金", "礼金", "所在地（何丁目まで）", "所在地（何番から）", "駅1の名前", "駅1までの所要時間（徒歩）", "駅2の名前", "駅2までの所要時間（徒歩）", "駅3の名前", "駅3までの所要時間（徒歩）", "物件種目", "構造・材質", "間取り", "階層（地上）", "階層（地下）", "所在階", "築年月", "専有面積", "建物名"];

    private static readonly String[] rentalDetailsTitle = ["建物名", "賃料", "管理費等", "維持費等", "敷金", "礼金", "保証金", "敷引・償却金", "所在地", "交通1", "徒歩距離1", "交通2", "徒歩距離2", "交通3", "徒歩距離3", "間取り（番号）", "間取り（タイプ）", "間取り（詳細）", "専有面積", "バルコニー面積", "新築", "築年月", "所在階", "階建", "主要採光面", "建物種類", "建物構造・工法", "エネルギー消費性能", "断熱性能", "目安光熱費", "保険等", "駐車場", "現況", "入居可能時期", "取引態様", "鍵タイプ", "条件等", "店舗・会社名", "店舗・会社番号", "管理システム番号", "総戸数", "情報公開日", "情報更新日", "次回更新予定日", "契約期間", "更新料", "保証会社", "その他初期費用", "その他諸費用", "備考", "フリーキーワード"];

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
                rentalSummary.Address, // 所在地
                rentalSummary.Station1Name, // 駅1の名前
                rentalSummary.Station1WalkMin, // 駅1までの所要時間（徒歩）
                rentalSummary.Station2Name, // 駅2の名前
                rentalSummary.Station2WalkMin, // 駅2までの所要時間（徒歩）
                rentalSummary.Station3Name, // 駅3の名前
                rentalSummary.Station3WalkMin, // 駅3までの所要時間（徒歩）
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

    public static List<String> RentalDetailsToCSV(Rental rental)
    {
        List<String> rentalDetailsList = [String.Format(rentalDetailsFormat, rentalDetailsTitle)];

        rentalDetailsList.Add(String.Format(rentalDetailsFormat,
            rental.BuildingName, // 建物名
            rental.Rent, // 賃料
            rental.ManagementFee, // 管理費等
            rental.MaintenanceFee, // 維持費等
            rental.SecurityDeposit, // 敷金
            rental.KeyMoney, // 礼金
            rental.GuaranteeMoney, // 保証金
            rental.DepositDeduction, // 敷引・償却金
            rental.Address, // 所在地
            rental.Transportation1, // 交通1
            rental.WalkingDistance1, // 徒歩距離1
            rental.Transportation2, // 交通2
            rental.WalkingDistance2, // 徒歩距離2
            rental.Transportation3, // 交通3
            rental.WalkingDistance3, // 徒歩距離3
            rental.LayoutNumber, // 間取り（番号）
            rental.LayoutType, // 間取り（タイプ）
            rental.LayoutDetails, // 間取り（詳細）
            rental.ExclusiveArea, // 専有面積
            rental.BalconyArea, // バルコニー面積
            rental.NewConstruction, // 新築
            rental.BuiltYearMonth, // 築年月
            rental.FloorNumber, // 所在階
            rental.TotalFloors, // 階建
            rental.MainLightDirection, // 主要採光面
            rental.BuildingType, // 建物種類
            rental.BuildingStructure, // 建物構造・工法
            rental.EnergyEfficiency, // エネルギー消費性能
            rental.InsulationPerformance, // 断熱性能
            rental.EstimatedUtilityCost, // 目安光熱費
            rental.Insurance, // 保険等
            rental.Parking, // 駐車場
            rental.CurrentCondition, // 現況
            rental.AvailableFrom, // 入居可能時期
            rental.TransactionType, // 取引態様
            rental.KeyType, // 鍵タイプ
            rental.RentalConditions, // 条件等
            rental.ShopCompanyName, // 店舗・会社名
            rental.ShopCompanyId, // 店舗・会社番号
            rental.ManagementSystemId, // 管理システム番号
            rental.TotalUnits, // 総戸数
            rental.PublishedDate, // 情報公開日
            rental.UpdatedDate, // 情報更新日
            rental.NextUpdateDate, // 次回更新予定日
            rental.ContractPeriod, // 契約期間
            rental.RenewalFee, // 更新料
            rental.GuarantorCompany, // 保証会社
            rental.OtherInitialCosts, // その他初期費用
            rental.OtherAdditionalCosts, // その他諸費用
            rental.Remarks, // 備考
            rental.FreeKeyword // フリーキーワード
        ));

        return rentalDetailsList;
    }
}