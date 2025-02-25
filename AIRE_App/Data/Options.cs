using AIRE_App.ViewModels;

namespace AIRE_App.Data;

public static class Options
{
    public static IReadOnlyList<ItemViewModel> No =
    [
        new() { ID = "-1", Name = "指定なし" }
    ];

    public static IReadOnlyList<ItemViewModel> NoMin =
    [
        new() { ID = "-1", Name = "下限なし" }
    ];

    public static IReadOnlyList<ItemViewModel> NoMax =
    [
        new() { ID = "-1", Name = "上限なし" }
    ];

    public static IReadOnlyList<ItemViewModel> Yachin =
    [
        new() { ID = "30000", Name = "3万円" },
        new() { ID = "35000", Name = "3.5万円" },
        new() { ID = "40000", Name = "4万円" },
        new() { ID = "45000", Name = "4.5万円" },
        new() { ID = "50000", Name = "5万円" },
        new() { ID = "55000", Name = "5.5万円" },
        new() { ID = "60000", Name = "6万円" },
        new() { ID = "65000", Name = "6.5万円" },
        new() { ID = "70000", Name = "7万円" },
        new() { ID = "75000", Name = "7.5万円" },
        new() { ID = "80000", Name = "8万円" },
        new() { ID = "85000", Name = "8.5万円" },
        new() { ID = "90000", Name = "9万円" },
        new() { ID = "95000", Name = "9.5万円" },
        new() { ID = "100000", Name = "10万円" },
        new() { ID = "105000", Name = "10.5万円" },
        new() { ID = "110000", Name = "11万円" },
        new() { ID = "115000", Name = "11.5万円" },
        new() { ID = "120000", Name = "12万円" },
        new() { ID = "125000", Name = "12.5万円" },
        new() { ID = "130000", Name = "13万円" },
        new() { ID = "135000", Name = "13.5万円" },
        new() { ID = "140000", Name = "14万円" },
        new() { ID = "145000", Name = "14.5万円" },
        new() { ID = "150000", Name = "15万円" },
        new() { ID = "155000", Name = "15.5万円" },
        new() { ID = "160000", Name = "16万円" },
        new() { ID = "165000", Name = "16.5万円" },
        new() { ID = "170000", Name = "17万円" },
        new() { ID = "175000", Name = "17.5万円" },
        new() { ID = "180000", Name = "18万円" },
        new() { ID = "185000", Name = "18.5万円" },
        new() { ID = "190000", Name = "19万円" },
        new() { ID = "195000", Name = "19.5万円" },
        new() { ID = "200000", Name = "20万円" },
        new() { ID = "210000", Name = "21万円" },
        new() { ID = "220000", Name = "22万円" },
        new() { ID = "230000", Name = "23万円" },
        new() { ID = "240000", Name = "24万円" },
        new() { ID = "250000", Name = "25万円" },
        new() { ID = "260000", Name = "26万円" },
        new() { ID = "270000", Name = "27万円" },
        new() { ID = "280000", Name = "28万円" },
        new() { ID = "290000", Name = "29万円" },
        new() { ID = "300000", Name = "30万円" },
        new() { ID = "350000", Name = "35万円" },
        new() { ID = "400000", Name = "40万円" },
        new() { ID = "500000", Name = "50万円" },
        new() { ID = "1000000", Name = "100万円" }
    ];

    public static IReadOnlyList<ItemViewModel> Toho =
    [
        new() { ID = "1", Name = "1分以内" },
        new() { ID = "5", Name = "5分以内" },
        new() { ID = "7", Name = "7分以内" },
        new() { ID = "10", Name = "10分以内" },
        new() { ID = "15", Name = "15分以内" },
        new() { ID = "20", Name = "20分以内" }
    ];

    public static IReadOnlyList<ItemViewModel> Men =
    [
        new() { ID = "20", Name = "20m²" },
        new() { ID = "25", Name = "25m²" },
        new() { ID = "30", Name = "30m²" },
        new() { ID = "35", Name = "35m²" },
        new() { ID = "40", Name = "40m²" },
        new() { ID = "45", Name = "45m²" },
        new() { ID = "50", Name = "50m²" },
        new() { ID = "55", Name = "55m²" },
        new() { ID = "60", Name = "60m²" },
        new() { ID = "65", Name = "65m²" },
        new() { ID = "70", Name = "70m²" },
        new() { ID = "80", Name = "80m²" },
        new() { ID = "90", Name = "90m²" },
        new() { ID = "100", Name = "100m²" }
    ];

    public static IReadOnlyList<ItemViewModel> Chikunensu =
    [
        new() { ID = "0", Name = "新築" },
        new() { ID = "1", Name = "1年以内" },
        new() { ID = "3", Name = "3年以内" },
        new() { ID = "5", Name = "5年以内" },
        new() { ID = "7", Name = "7年以内" },
        new() { ID = "10", Name = "10年以内" },
        new() { ID = "15", Name = "15年以内" },
        new() { ID = "20", Name = "20年以内" },
        new() { ID = "25", Name = "25年以内" },
        new() { ID = "30", Name = "30年以内" }
    ];
}