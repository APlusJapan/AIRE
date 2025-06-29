using System.Text.RegularExpressions;
using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using OpenAI.Responses;

namespace AIRE_App.Services.AIServices;

public class DetailsAIService : IAIService
{
    private const String modelaName = "gpt-4o";

    private const String idKey = "DetailsAIService";

    private const String OpenLineFunctionName = "OpenLine";

    private const String OpenLineFunctionDescription = "不動産会社のLINE友達追加画面を開く";

    private const String OpenLinefunctionOutput = "取り扱う店舗の LINE 友達追加画面が開いた";

    private MessageResponseItem systemMessageResponseItem;

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly ResponseCreationOptions responseCreationOptions;

    private readonly Regex urlLinkRegex = new(@"#* *\(?\[.*?\]\(.*?\)\)?");

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";


    public DetailsAIService()
    {
        var functionJsonSchema = """
        {
            "type": "object",
            "properties": {},
            "additionalProperties": false,
            "required": []
        }
        """;

        openAIResponseClient = new OpenAIResponseClient(modelaName, apiKey);

        responseCreationOptions = new ResponseCreationOptions();

        responseCreationOptions.Tools.Add(ResponseTool.CreateWebSearchTool());

        responseCreationOptions.Tools.Add(ResponseTool.CreateFunctionTool(OpenLineFunctionName, OpenLineFunctionDescription, new BinaryData(functionJsonSchema)));
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

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        if (openAIResponse.OutputItems.First() is FunctionCallResponseItem functionCallResponseItem)
        {
            switch(functionCallResponseItem.FunctionName)
            {
                case OpenLineFunctionName:
                {
                    await PostFunctionCallOutputAsync(functionCallResponseItem.CallId, OpenLinefunctionOutput, messageProcessor);
                    await shellMover?.Invoke(String.Empty);
                    break;
                }
            }
        }
        else
        {
            Preferences.Set(idKey, openAIResponse.Id);

            var output = openAIResponse.GetOutputText();

            await messageProcessor?.Invoke(new()
            {
                Role = "assistant",
                Text = urlLinkRegex.Replace(output, String.Empty).Trim()
            });
        }
    }

    private async Task PostFunctionCallOutputAsync(String callId, String functionOutput, Func<MessageViewModel, Task> messageProcessor)
    {
        OpenAIResponse openAIResponse;

        var functionCallOutputItem = ResponseItem.CreateFunctionCallOutputItem(callId, functionOutput);

        openAIResponse = await openAIResponseClient.CreateResponseAsync([functionCallOutputItem], responseCreationOptions);

        Preferences.Set(idKey, openAIResponse.Id);

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        var output = openAIResponse.GetOutputText();

        await messageProcessor?.Invoke(new()
        {
            Role = "assistant",
            Text = urlLinkRegex.Replace(output, String.Empty).Trim()
        });
    }
}