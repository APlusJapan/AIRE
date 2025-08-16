using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using AIRE_DB.Models;
using OpenAI.Responses;
using System.Text.Json;
using System.Text.RegularExpressions;

#pragma warning disable OPENAI001

namespace AIRE_App.Services.AIServices;

public class SqlAIService : IAIService
{
    private const String modelaName = "gpt-4o";

    private const String idKey = App.SqlAIServiceKey;

    private const String businessPromptSendTimeKey = $"{idKey}BusinessPromptSendTime";

    private DateTime businessPromptSendTime;

    private DateTime businessPromptUpdateTime;

    private const String searchFromSQLFunctionName = "SearchFromSQL";

    private const String searchFromSQLFunctionDescription = "テーブル rental_summary の SQL クエリを実行し、クエリ結果を表示する";

    private const String searchFromSQLfunctionOutput = "クエリが完了した";

    private MessageResponseItem systemInitMessageResponseItem;

    private MessageResponseItem businessInitMessageResponseItem;

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly ResponseCreationOptions responseCreationOptions;

    private readonly Regex urlLinkRegex = new(@"#* *\(?\[.*?\]\(.*?\)\)?");

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    public SqlAIService()
    {
        var functionJsonSchema = """
        {
            "type": "object",
            "properties":
            {
                "sql":
                {
                    "type": "string",
                    "description": "The SQL query statement you want to execute"
                }
            },
            "additionalProperties": false,
            "required": ["sql"]
        }
        """;

        var dateTimeString = Preferences.Get(businessPromptSendTimeKey, DateTime.MinValue.ToString("s"));

        businessPromptSendTime = DateTime.ParseExact(dateTimeString, "s", null);

        openAIResponseClient = new OpenAIResponseClient(modelaName, apiKey);

        responseCreationOptions = new ResponseCreationOptions();

        responseCreationOptions.Tools.Add(ResponseTool.CreateWebSearchTool());

        responseCreationOptions.Tools.Add(ResponseTool.CreateFunctionTool(searchFromSQLFunctionName, searchFromSQLFunctionDescription, new BinaryData(functionJsonSchema)));
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
        businessPromptUpdateTime = businessInitPrompt.ModificationTime ?? DateTime.Now;

        systemInitMessageResponseItem = ResponseItem.CreateSystemMessageItem(systemInitPrompt.PromptValue);

        businessInitMessageResponseItem = ResponseItem.CreateSystemMessageItem(businessInitPrompt.PromptValue);
    }

    private List<ResponseItem> GetInitResponseItemList()
    {
        List<ResponseItem> responseItemList = [];

        if (String.IsNullOrWhiteSpace(responseCreationOptions.PreviousResponseId))
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

    public Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor)
    {
        throw new NotImplementedException();
    }

    public async Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover)
    {
        OpenAIResponse openAIResponse;

        List<ResponseItem> responseItemList = GetInitResponseItemList();

        var userMessageResponseItem = ResponseItem.CreateUserMessageItem(message);

        responseItemList.Add(userMessageResponseItem);

        openAIResponse = await openAIResponseClient.CreateResponseAsync(responseItemList, responseCreationOptions);

        responseCreationOptions.PreviousResponseId = openAIResponse.Id;

        var output = openAIResponse.GetOutputText();

        if (openAIResponse.OutputItems.First() is FunctionCallResponseItem functionCallResponseItem)
        {
            switch (functionCallResponseItem.FunctionName)
            {
                case searchFromSQLFunctionName:
                    {
                        await PostFunctionCallOutputAsync(functionCallResponseItem.CallId, searchFromSQLfunctionOutput, messageProcessor);
                        using JsonDocument sqlJsonDocument = JsonDocument.Parse(functionCallResponseItem.FunctionArguments);
                        string rawSQL = sqlJsonDocument.RootElement.GetProperty("sql").GetString();
                        await shellMover?.Invoke(rawSQL);
                        break;
                    }
            }
        }
        else
        {
            Preferences.Set(idKey, openAIResponse.Id);

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