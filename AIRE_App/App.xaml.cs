using AIRE_App.Data;
using AIRE_App.Interfaces;
using AIRE_App.Services;
using AIRE_App.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;

namespace AIRE_App;

public partial class App : Application
{
    public const String InitPromptType = "Init";

    public const String ExtraPromptType = "Extra";

    public const String SqlAIServiceKey = "SqlAIService";

    public const String DetailsAIServiceKey = "DetailsAIService";

    public ISession Session { get; }

    public IDictionary<Object, Object> Items { get; }

    public App(AIStatusViewModel aiStatusViewModel,
        [FromKeyedServices(SqlAIServiceKey)] IAIService sqlAIService,
        [FromKeyedServices(DetailsAIServiceKey)] IAIService detailsAIService)
    {
        InitializeComponent();

        Session = new MySession();

        Items = new ConcurrentDictionary<Object, Object>();

        if (Preferences.ContainsKey(SqlAIServiceKey))
        {
            var id = Preferences.Get(SqlAIServiceKey, String.Empty);
            sqlAIService.SetID(id);
        }

        if (Preferences.ContainsKey(DetailsAIServiceKey))
        {
            var id = Preferences.Get(DetailsAIServiceKey, String.Empty);
            detailsAIService.SetID(id);
        }

        var sqlAISystemInitPrompt = PromptService.GetPromptMaster(SqlAIServiceKey, PromptType.SystemInit);
        var sqlAIBusinessInitPrompt = PromptService.GetPromptMaster(SqlAIServiceKey, PromptType.BusinessInit);
        var sqlAIExtraPrompt = PromptService.GetPromptMaster(SqlAIServiceKey, PromptType.Extra);

        sqlAIService.SetPrompt(sqlAISystemInitPrompt,
            sqlAIBusinessInitPrompt,
            sqlAIExtraPrompt);

        var detailsAISystemInitPrompt = PromptService.GetPromptMaster(DetailsAIServiceKey, PromptType.SystemInit);
        var detailsAIBusinessInitPrompt = PromptService.GetPromptMaster(DetailsAIServiceKey, PromptType.BusinessInit);
        var detailsAIExtraPrompt = PromptService.GetPromptMaster(DetailsAIServiceKey, PromptType.Extra);

        detailsAIService.SetPrompt(detailsAISystemInitPrompt,
            detailsAIBusinessInitPrompt,
            detailsAIExtraPrompt);

        JSONService.InitMessage(aiStatusViewModel);
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return new Window(new AppShell());
    }

    private class MySession : ISession
    {
        private IDictionary<String, byte[]> dictionary = new ConcurrentDictionary<String, byte[]>();

        public bool IsAvailable
        {
            get
            {
                return true;
            }
        }

        public String Id
        {
            get
            {
                return UniqueIDService.GetDeviceID();
            }
        }

        public IEnumerable<String> Keys
        {
            get
            {
                return dictionary.Keys;
            }
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Remove(String key)
        {
            dictionary.Remove(key);
        }

        public void Set(String key, byte[] value)
        {
            dictionary[key] = value;
        }

        public bool TryGetValue(String key, out byte[] value)
        {
            return dictionary.TryGetValue(key, out value);
        }
    }
}