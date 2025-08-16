namespace AIRE_App.Data;

public enum SearchType
{
    None,
    Station,
    Area
}

public enum PromptType
{
    SystemInit,
    BusinessInit,
    Extra
}

public enum RegionType
{
    Hokkaido, // 北海道
    Tohoku, // 東北
    Kanto, // 関東
    Koshinetsu, // 甲信越・北陸
    Tokai, // 東海
    Kansai, // 関西
    Chugoku, // 中国
    Shikoku, // 四国
    Kyushu // 九州・沖縄
}