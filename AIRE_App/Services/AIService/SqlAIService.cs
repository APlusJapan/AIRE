using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using OpenAI.Responses;

namespace AIRE_App.Services.AIServices;

public class SqlAIService : IAIService
{
    private const String modelaName = "gpt-4o";

    private const String idKey = "SqlAIService";

    private const String markdownSuffix = "```";

    private const String markdownPrefix = "```sql";

    private MessageResponseItem systemMessageResponseItem;

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly ResponseCreationOptions responseCreationOptions;

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    public SqlAIService()
    {
        openAIResponseClient = new OpenAIResponseClient(modelaName, apiKey);

        responseCreationOptions = new ResponseCreationOptions();

        responseCreationOptions.Tools.Add(ResponseTool.CreateWebSearchTool());
    }

    public void SetID(String id)
    {
        responseCreationOptions.PreviousResponseId = id;
    }

    public void SetPrompt(String initPrompt, String extraPrompt)
    {
        var systemPrompt = initPrompt;

        systemMessageResponseItem = ResponseItem.CreateSystemMessageItem(systemPrompt);
    }

    public Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor)
    {
        throw new NotImplementedException();
    }

    public async Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover)
    {
        OpenAIResponse openAIResponse;

        var userMessageResponseItem = ResponseItem.CreateUserMessageItem(message);

        if (String.IsNullOrWhiteSpace(responseCreationOptions.PreviousResponseId))
        {
            openAIResponse = await openAIResponseClient.CreateResponseAsync([systemMessageResponseItem, userMessageResponseItem], responseCreationOptions);
        }
        else
        {
            openAIResponse = await openAIResponseClient.CreateResponseAsync([userMessageResponseItem], responseCreationOptions);
        }

        Preferences.Set(idKey, openAIResponse.Id);

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        var output = openAIResponse.GetOutputText();

        if (output.StartsWith(markdownPrefix) && output.EndsWith(markdownSuffix))
        {
            int startIndex = markdownPrefix.Length;
            int sqlLength = output.Length - markdownPrefix.Length - markdownSuffix.Length;

            var rawSQL = output.Substring(startIndex, sqlLength);

            await shellMover?.Invoke(rawSQL);

            return;
        }

        await messageProcessor?.Invoke(new()
        {
            Role = "assistant",
            Text = output
        });
    }
}