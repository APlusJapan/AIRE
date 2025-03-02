namespace AIRE_App.Data;

public static class Constants
{
    public const String Toho = "歩{0}分";

    public const String Shinchiku = "新築";

    public const String Chikunen = "築{0}年";

    public const String Chikutsuki = "築{0}月";

    public const String ChikunenChikutsuki = "築{0}年{1}月";

    public const String Chika = "地下";

    public const String Chijou = "地上";

    public const String ChijouSyokai = "{0}階";

    public const String ChijouKaisou = "{0}階建";

    public const String ChikaSyokai = "地下{0}階";

    public const String ChikaKaisou = "地下{0}階建";

    public const String ChijouChikaKaisou = "地上{0}地下{0}階建";

    public const String Yen = "{0}円";

    public const String ManYen = "{0}万円";

    public const String OkuYen = "{0}億円";

    public const String OkuManYen = "{0}億{1}万円";

    public static readonly String PostgreSQLConnectionString = $"Host=localhost;Username=postgres;Password=root;Database=AIRE_DB";

    public static readonly String SQLiteConnectionString = $"Data Source={Path.Combine(FileSystem.AppDataDirectory, "AIRE_SQLite")}";
}