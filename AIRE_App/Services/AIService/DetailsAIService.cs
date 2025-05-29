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

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly MessageResponseItem systemMessageResponseItem;

    private readonly ResponseCreationOptions responseCreationOptions;

    private readonly Regex urlLinkRegex = new(@"#* *\(?\[.*?\]\(.*?\)\)?");

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    private const String recommendPrompt = "以下は見つかったデータです。この物件のメリットを紹介してください。";

    public DetailsAIService()
    {
        var systemPrompt = """
        あなたは住宅仲介の営業担当者です。ユーザーに物件を紹介する際、提供されたCSV形式の物件情報をもとに、自然な会話口調で物件の魅力を伝えてください。物件の基本情報だけでなく、周辺環境や生活の利便性、交通アクセス、近隣施設や観光スポットなども織り交ぜて紹介してください。まずはリラックスした自然な語り口で物件の魅力を伝え、その後、質問を交えながらユーザーの希望や興味を引き出してください。ユーザーが関心を示したポイントについては、その心理をとらえたうえで、該当物件がその面で優れている点をさらに詳しく説明し、「物件の管理会社に詳細な資料があります」とお伝えください。最後に、親しみやすい口調で「よければ会社のLINEを追加していただけますか？追加していただければ、もっと詳しい資料をお送りしますね」と提案してください。

        【要件】
        ・会話口調で、自然で親しみやすく、押し売り感を出さないこと
        ・物件の特徴を際立たせ、ユーザーの興味を引く
        ・質問形式でユーザーとやり取りし、関心ポイントを引き出す
        ・ユーザーの関心に応じて「管理会社に詳細な資料がある」と伝える
        ・軽いトーンでLINE追加を提案し、今後のやり取りがしやすいようにする
        ・全体として親しみやすく信頼感を持てる語り口で
        ・物件の魅力を簡潔に伝え、対話を進め、最後に自然な形でLINE誘導する

        【入力データ形式（CSVの例）：】
        建物名, 賃料, 管理費等, 維持費等, 敷金, 礼金, 保証金, 敷引・償却金, 所在地, 交通1, 徒歩距離1, 交通2, 徒歩距離2, 交通3, 徒歩距離3, 間取り（番号）, 間取り（タイプ）, 間取り（詳細）, 専有面積, バルコニー面積, 新築, 築年月, 所在階, 階建, 主要採光面, 建物種類, 建物構造・工法, エネルギー消費性能, 断熱性能, 目安光熱費, 保険等, 駐車場, 現況, 入居可能時期, 取引態様, 鍵タイプ, 条件等, 店舗・会社名, 店舗・会社番号, 管理システム番号, 総戸数, 情報公開日, 情報更新日, 次回更新予定日, 契約期間, 更新料, 保証会社, その他初期費用, その他諸費用, 備考, フリーキーワード
        パレスホテル東京, 100000, 20000, 0, -, -, -, 7万円, 東京都千代田区丸の内１-1-1, 東京地下鉄9号線千代田線二重橋前, 3, 東日本旅客鉄道東海道線東京, 1, 東京都6号線三田線大手町, 5, 6, 15, , 150, , True, 2012/02/01, 1階, 5階建, 南, 賃貸, S造（軽量鉄骨造）, , , , , -, , , , , ペット相談, , , , , , , , , , , , , サンプル物件, ペット相談

        【出力例：】
        ・こちらの5LDKのお部屋は「ロイヤルパレスホテル東京」内にありまして、二重橋前駅まで徒歩3分、東京駅もすぐ近くで、アクセス抜群なんです。皇居の緑が見えて、生活の質もとても高いですよ～
        ・普段は、生活の利便性を重視されますか？それとも、静かで落ち着いた環境がお好みですか？
        ・ちょうどこの物件、セキュリティがしっかりしていて、周辺施設も充実しています。管理会社の方で、もっと詳しい資料がありますよ。
        ・よければ、会社のLINEを追加していただけますか？追加していただければ、詳細な資料をお送りしますので、ぜひ参考にしてくださいね～
        """;

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

        systemMessageResponseItem = ResponseItem.CreateSystemMessageItem(systemPrompt);
    }

    public void SetID(String id)
    {
        responseCreationOptions.PreviousResponseId = id;
    }

    public async Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor)
    {
        String[] promptArray = [recommendPrompt, .. recommendList];

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