using System.Collections.Frozen;
using AIRE_DB.Models;

namespace AIRE_App.Services;

public static class StationService
{
    private static readonly Lock iLock = new();

    private static readonly App app = Application.Current as App;

    private static IReadOnlyDictionary<String, Station> dictionary;

    private static void Init()
    {
        lock (iLock)
        {
            if (dictionary == null)
            {
                if (!app.Items.TryGetValue(nameof(Station), out Object value)
                    || value is not Station[])
                {
                    value = app.Items[nameof(Station)] = DatabaseService.GetAireDbContext().Stations.ToArray();
                }

                var stations = value as Station[];

                dictionary = stations.ToFrozenDictionary(station => station.StationId);
            }
        }
    }

    public static Station GetStation(String stationId)
    {
        if (dictionary == null)
        {
            Init();
        }

        return dictionary[stationId];
    }
}