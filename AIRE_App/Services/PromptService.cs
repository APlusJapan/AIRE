using System.Collections.Concurrent;
using AIRE_App.Data;
using ApiSdk;
using ApiSdk.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace AIRE_App.Services;

public static class PromptService
{
    private static ApiClient apiClient;

    private static readonly Lock iLock = new();

    private static readonly App app = Application.Current as App;

    private static IDictionary<String, PromptMaster> initDictionary;

    private static void Init()
    {
        //lock (iLock)
        {
            if (initDictionary == null)
            {
                initDictionary = new ConcurrentDictionary<String, PromptMaster>();

                // API requires no authentication, so use the anonymous
                // authentication provider
                var authenticationProvider = new AnonymousAuthenticationProvider();
                // Create request adapter using the HttpClient-based implementation
                var requestAdapter = new HttpClientRequestAdapter(authenticationProvider)
                {
                    BaseUrl = Constants.ServerUrl
                };
                // Create the API client
                apiClient = new ApiClient(requestAdapter);
            }
        }
    }

    public static PromptMaster GetInitPromptMaster(String promptName)
    {
        if (initDictionary == null)
        {
            Init();
        }

        bool contained = initDictionary.TryGetValue(promptName, out PromptMaster promptMaster);

        if (!contained)
        {
            promptMaster = apiClient.Prompt.Init.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.PromptName = promptName;
            }).Result;

            initDictionary.Add(promptName, promptMaster);
        }

        return promptMaster;
    }

    public async static Task<PromptMaster> GetExtraPromptMaster(String promptName)
    {
        if (initDictionary == null)
        {
            Init();
        }

        var promptMaster = await apiClient.Prompt.Extra.GetAsync(requestConfiguration =>
        {
            requestConfiguration.QueryParameters.PromptName = promptName;
        });

        return promptMaster;
    }
}