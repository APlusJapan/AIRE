using System.Text.RegularExpressions;
using AIRE_App.Interfaces;
using AIRE_App.ViewModels;
using OpenAI.Responses;

namespace AIRE_App.Services.AIServices;

public class ChatAIService : IAIService
{
    private const String modelaName = "gpt-4o";

    private const String idKey = "ChatAIService";

    private readonly OpenAIResponseClient openAIResponseClient;

    private readonly MessageResponseItem systemMessageResponseItem;

    private readonly ResponseCreationOptions responseCreationOptions;

    private readonly Regex urlLinkRegex = new(@"#* *\(?\[.*?\]\(.*?\)\)?");

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    private const String recommendPrompt = "以下は見つかったデータです。この物件のメリットを紹介してください。";

    public ChatAIService()
    {
        var systemPrompt = """
        あなたは住宅仲介業者の営業担当です。ユーザーに物件を紹介する際、以下のCSV形式で提供される物件情報をもとに、自然な会話調で魅力を伝えてください。ただ物件の基本情報だけでなく、周辺環境や生活利便性、アクセスの良さ、近隣の施設・観光スポットなども織り交ぜ物件を説明するのではなく、ユーザーの心に響くポイントを押さえた上で、「ちょっと話を聞いてみようかな」と思ってもらえるような一言（例：気軽な問い合わせや内見への誘導）を最後に添えてください。

        【要件】
        ・出力は1物件につき100文字以内
        ・会話調で、押しつけがましくない自然な営業トーク
        ・物件の特徴を活かした魅力づけ＋自然なアクション誘導（連絡・内見への興味）
        ・ユーザーとの信頼を築ける、親しみやすいトーンで
        ・物件の特長を生かした魅力的な一言＋軽いクロージング（例：内見、相談、問い合わせ など）

        【入力データの形式（CSV例）：】
        家賃, 管理費, 敷金, 礼金, 所在地（何丁目まで）, 所在地（何番から）, 駅1の名前, 駅1までの所要時間（バス）, 駅1までの所要時間（徒歩）, 駅1までの所要時間（車）, 駅2の名前, 駅2までの所要時間（バス）, 駅2までの所要時間（徒歩）, 駅2までの所要時間（車）, 駅3の名前, 駅3までの所要時間（バス）, 駅3までの所要時間（徒歩）, 駅3までの所要時間（車）, 物件種目, 構造・材質, 間取り, 階層（地上）, 階層（地下）, 所在階, 築年月, 専有面積, 建物名
        100000.00, 20000.00, 100000.00, 100000.00, 東京都千代田区丸の内1, 1-1, 東京地下鉄9号線千代田線二重橋前, , 3, , 東日本旅客鉄道東海道線東京, , 1, , 東京都6号線三田線大手町, , 5, , 賃貸居住用, 鉄骨鉄筋コンクリート, 5ＬＤＫ, 23, 4, 1, 2012/02/14, 256.00, パレスホテル東京

        【出力例：】
        ・​パレスホテル東京内の5LDK賃貸物件です。​二重橋前駅から徒歩3分、東京駅へも徒歩圏内でアクセス良好。​皇居外苑の緑を望むロケーションで、都心でありながら自然を感じる生活が可能です。​周辺には高級ブランドショップや多彩なレストランが集まる丸の内仲通りがあり、ショッピングやグルメも楽しめます。​内見のご希望がございましたら、お気軽にお問い合わせください。
        """;

        openAIResponseClient = new OpenAIResponseClient(modelaName, apiKey);

        responseCreationOptions = new ResponseCreationOptions();

        responseCreationOptions.Tools.Add(ResponseTool.CreateWebSearchTool());

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

    public Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover)
    {
        throw new NotImplementedException();
    }
}