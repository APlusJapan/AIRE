using System.Text.RegularExpressions;
using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using OpenAI.Responses;

namespace AIRE_App.Services.AIServices;

public class SummaryAIService : IAIService
{
    private const String modelaName = "gpt-4o";

    private const String idKey = "SummaryAIService";

    private MessageResponseItem systemMessageResponseItem;

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly ResponseCreationOptions responseCreationOptions;

    private readonly Regex urlLinkRegex = new(@"#* *\(?\[.*?\]\(.*?\)\)?");

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    public SummaryAIService()
    {
        openAIResponseClient = new OpenAIResponseClient(modelaName, apiKey);

        responseCreationOptions = new ResponseCreationOptions();

        responseCreationOptions.Tools.Add(ResponseTool.CreateWebSearchTool());
    }

    public void SetID(String id)
    {
        responseCreationOptions.PreviousResponseId = id;
    }

    public void SetInitPrompt(String initPrompt)
    {
        var systemPrompt = initPrompt;

        systemMessageResponseItem = ResponseItem.CreateSystemMessageItem(systemPrompt);
    }

    public async Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor)
    {
        var extraPromptMaster = await PromptService.GetExtraPromptMaster(idKey);

        String[] promptArray = [extraPromptMaster.PromptValue, .. recommendList];

        var message = String.Join("\n", promptArray);

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

        await messageProcessor?.Invoke(new()
        {
            Role = "assistant",
            Text = urlLinkRegex.Replace(output, String.Empty).Trim()
        });
    }

    public Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover)
    {
        throw new NotImplementedException();
    }
}