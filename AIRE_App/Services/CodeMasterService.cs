using System.Collections.Frozen;
using AIRE_DB.Models;

namespace AIRE_App.Services;

public static class CodeMasterService
{
    private static readonly Lock iLock = new();

    private static readonly App app = Application.Current as App;

    private static IReadOnlyDictionary<String, IReadOnlyDictionary<String, CodeMaster>> dictionary;

    private static void Init()
    {
        lock (iLock)
        {
            if (dictionary == null)
            {
                if (!app.Items.TryGetValue(nameof(CodeMaster), out Object value)
                    || value is not CodeMaster[])
                {
                    value = app.Items[nameof(CodeMaster)] = DatabaseService.GetAireDbContext().CodeMasters.ToArray();
                }

                var codeMasters = value as CodeMaster[];

                dictionary = codeMasters.GroupBy(codeMaster => codeMaster.CodeType)
                    .ToFrozenDictionary(group => group.Key, group =>
                        (IReadOnlyDictionary<String, CodeMaster>)group.ToFrozenDictionary(item => item.OptionValue));
            }
        }
    }

    public static IReadOnlyDictionary<String, CodeMaster> GetCodeMasters(String codeType)
    {
        if (dictionary == null)
        {
            Init();
        }

        return dictionary[codeType];
    }

    public static CodeMaster GetCodeMaster(String codeType, String optionValue)
    {
        if (dictionary == null)
        {
            Init();
        }

        return dictionary[codeType][optionValue];
    }
}