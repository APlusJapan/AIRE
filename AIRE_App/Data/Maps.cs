using AIRE_App.ViewModels;

namespace AIRE_App.Data;

public static class Maps
{
    public static readonly IReadOnlyDictionary<RegionType, String[]> RegionToPrefectureIDMap =
        new Dictionary<RegionType, String[]>
        {
            // 北海道
            [RegionType.Hokkaido] = ["01000"],

            // 東北
            [RegionType.Tohoku] = ["02000", "03000", "04000", "05000", "06000", "07000"],

            // 関東
            [RegionType.Kanto] = ["08000", "09000", "10000", "11000", "12000", "13000", "14000"],

            // 甲信越・北陸
            [RegionType.Koshinetsu] = ["15000", "16000", "17000", "18000", "19000", "20000"],

            // 東海
            [RegionType.Tokai] = ["21000", "22000", "23000", "24000"],

            // 関西
            [RegionType.Kansai] = ["25000", "26000", "27000", "28000", "29000", "30000"],

            // 中国
            [RegionType.Chugoku] = ["31000", "32000", "33000", "34000", "35000"],

            // 四国
            [RegionType.Shikoku] = ["36000", "37000", "38000", "39000"],

            // 九州・沖縄
            [RegionType.Kyushu] = ["40000", "41000", "42000", "43000", "44000", "45000", "46000", "47000"]
        };
}