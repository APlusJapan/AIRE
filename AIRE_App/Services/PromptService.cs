using System.Collections.Frozen;
using AIRE_App.Data;
using AIRE_DB.Models;

namespace AIRE_App.Services;

public static class PromptService
{
    private static readonly Lock iLock = new();

    private static readonly App app = Application.Current as App;

    private static IReadOnlyDictionary<String, IReadOnlyDictionary<String, PromptMaster>> dictionary;

    private static void Init()
    {
        lock (iLock)
        {
            if (dictionary == null)
            {
                if (!app.Items.TryGetValue(nameof(PromptMaster), out Object value)
                    || value is not PromptMaster[])
                {
                    value = app.Items[nameof(PromptMaster)] = DatabaseService.GetAireDbContext().PromptMasters.ToArray();
                }

                var promptMasters = value as PromptMaster[];

                dictionary = promptMasters.GroupBy(promptMasters => promptMasters.PromptName)
                    .ToFrozenDictionary(group => group.Key, group =>
                        (IReadOnlyDictionary<String, PromptMaster>)group.ToFrozenDictionary(item => item.PromptType));
            }
        }
    }

    public static IReadOnlyDictionary<String, PromptMaster> GetPromptMasters(String promptName)
    {
        if (dictionary == null)
        {
            Init();
        }

        return dictionary[promptName];
    }

    public static PromptMaster GetPromptMaster(String promptName, PromptType promptType)
    {
        if (dictionary == null)
        {
            Init();
        }

        return dictionary[promptName][promptType.ToString()];
    }
}