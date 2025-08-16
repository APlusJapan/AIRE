using System.Text.RegularExpressions;
using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace AIRE_App.Services.AIServices;

public class DetailsAIService : IAIService
{
    private static String recommendPrompt;

    private bool systemInitialized = false;

    private const String modelaName = "gpt-4o";

    private const String idKey = App.DetailsAIServiceKey;

    private static DateTime businessPromptUpdateTime;

    private DateTime businessPromptSendTime = DateTime.MinValue;

    private const String OpenLineFunctionName = "OpenLine";

    private const String OpenLineFunctionDescription = "不動産会社のLINE友達追加画面を開く";

    private const String OpenLinefunctionOutput = "取り扱う店舗の LINE 友達追加画面が開いた";

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly ResponseCreationOptions responseCreationOptions;

    private static MessageResponseItem systemInitMessageResponseItem;

    private static MessageResponseItem businessInitMessageResponseItem;

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

    public String GetID()
    {
        return responseCreationOptions.PreviousResponseId;
    }

    public void SetID(String id)
    {
        responseCreationOptions.PreviousResponseId = id;
    }

    public void SetPrompt(PromptMaster systemInitPrompt, PromptMaster businessInitPrompt, PromptMaster extraPrompt)
    {
        recommendPrompt = extraPrompt.PromptValue;

        businessPromptUpdateTime = businessInitPrompt.ModificationTime ?? DateTime.Now;

        systemInitMessageResponseItem = ResponseItem.CreateSystemMessageItem(systemInitPrompt.PromptValue);

        businessInitMessageResponseItem = ResponseItem.CreateSystemMessageItem(businessInitPrompt.PromptValue);
    }

    private List<ResponseItem> GetInitResponseItemList()
    {
        List<ResponseItem> responseItemList = [];

        if (!systemInitialized)
        {
            responseItemList.Add(systemInitMessageResponseItem);
        }

        if (businessPromptSendTime.CompareTo(businessPromptUpdateTime) < 0)
        {
            businessPromptSendTime = businessPromptUpdateTime;

            responseItemList.Add(businessInitMessageResponseItem);
        }

        return responseItemList;
    }

    public async Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor)
    {
        String[] promptArray = [recommendPrompt, .. recommendList];

        var message = String.Join("\n", promptArray);

        OpenAIResponse openAIResponse;

        List<ResponseItem> responseItemList = GetInitResponseItemList();

        var userMessageResponseItem = ResponseItem.CreateUserMessageItem(message);

        responseItemList.Add(userMessageResponseItem);

        openAIResponse = await openAIResponseClient.CreateResponseAsync(responseItemList, responseCreationOptions);

        systemInitialized = true;

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

        List<ResponseItem> responseItemList = GetInitResponseItemList();

        var userMessageResponseItem = ResponseItem.CreateUserMessageItem(message);

        responseItemList.Add(userMessageResponseItem);

        openAIResponse = await openAIResponseClient.CreateResponseAsync(responseItemList, responseCreationOptions);

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        if (openAIResponse.OutputItems.First() is FunctionCallResponseItem functionCallResponseItem)
        {
            switch (functionCallResponseItem.FunctionName)
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

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        var output = openAIResponse.GetOutputText();

        await messageProcessor?.Invoke(new()
        {
            Role = "assistant",
            Text = urlLinkRegex.Replace(output, String.Empty).Trim()
        });
    }
}