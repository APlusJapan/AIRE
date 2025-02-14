namespace AIRE_App.Data;

public static class Constants
{
    public static readonly String PostgreSQLConnectionString = $"Host=localhost;Username=postgres;Password=root;Database=AIRE_DB";

    public static readonly String SQLiteConnectionString = $"Data Source={Path.Combine(FileSystem.AppDataDirectory, "AIRE_SQLite")}";
}