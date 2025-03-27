using AIRE_App.Interfaces;
using OpenAI.Chat;

namespace AIRE_App.Services.AIServices;

public class SqlAIService : IAIService
{
    private const String modelaName = "gpt-4o-search-preview";

    private const String markdownSuffix = "```";

    private const String markdownPrefix = "```sql";
    public List<ChatMessage> ChatMessageList { get; } = [];

    private const String apiKey = "sk-2UWxCOHGalGf9Whr5TGqxPF0ff673kkSxx6grYqErTT3BlbkFJ1EZi0KeYvH4FGC0JjVBNvRno4E-tmSB7PjFDlvttYA";

    public SqlAIService()
    {
        var systemPrompt = """
        あなたは現在、不動産仲介業者として振る舞います。
        ユーザーとの対話を通じて、ユーザーの住宅に関するニーズを引き出し、データベース検索用の SQL コードを生成してください。

        以下の要件を厳守してください：
        1. SQL コードのみを返し、余計な説明やテキストは一切含めないこと。
        2. 複数の SQL コードを返さないこと。
        3. SQL クエリの生成に成功した場合のみ、Markdown 記法を用いてコードを囲むこと。例：
        ```sql
        SELECT *
        FROM rental_summary
        WHERE prefecture_name LIKE '%東京都%'
        ```
        4. SQL クエリを生成できない場合は、何も出力せず空白の状態にすること（Markdown 記法やその他のテキストを出力しないこと）。
        5. 文字列の比較には "=" を避け、"LIKE" を使用してマッチングすること。。

        ユーザーが小学校に関する問い合わせをした場合、以下の URL の情報を利用してください：
        1. https://www.minkou.jp/primary/ranking/review/

        データベーステーブルの構造は以下の通りです：
        CREATE TABLE rental_summary
        (
            rental_id varchar(40) Not Null,
            prefecture_name varchar(10) Not Null,
            area_name varchar(10) Not Null,
            property_type varchar(32) Not Null,
            price decimal(15, 2) Not Null,
            management_fee decimal(10, 2) DEFAULT 0,
            security_deposit decimal(10, 2) Not Null,
            key_money decimal(10, 2) Not Null,
            address_street_part varchar(40) Not Null,
            address_number_part varchar(40) Not Null,
            station1_name varchar(40),
            station1_bus_min smallint,
            station1_walk_min smallint,
            station1_car_time smallint,
            station2_name varchar(40),
            station2_bus_min smallint,
            station2_walk_min smallint,
            station2_car_time smallint,
            station3_name varchar(40),
            station3_bus_min smallint,
            station3_walk_min smallint,
            station3_car_time smallint,
            property_category varchar(32),
            structure_material varchar(32) DEFAULT '不明',
            floor_plan_type varchar(32),
            above_ground_floors smallint,
            below_ground_floors smallint,
            current_floor smallint,
            construction_date date Not Null,
            exclusive_area decimal(5, 2) Not Null,
            building_name varchar(40),
            exterior_photo varchar(255),
            floor_plan_image varchar(255),
            recommend boolean Not Null DEFAULT FALSE,
            PRIMARY KEY (rental_id)
        );

        COMMENT ON TABLE rental_summary IS '賃貸物件概要';
        COMMENT ON COLUMN rental_summary.rental_id IS '賃貸物件ID';
        COMMENT ON COLUMN rental_summary.prefecture_name IS '都道府県名';
        COMMENT ON COLUMN rental_summary.area_name IS 'エリア名';
        COMMENT ON COLUMN rental_summary.property_type IS '物件タイプ';
        COMMENT ON COLUMN rental_summary.price IS '家賃、価格';
        COMMENT ON COLUMN rental_summary.management_fee IS '管理費';
        COMMENT ON COLUMN rental_summary.security_deposit IS '敷金';
        COMMENT ON COLUMN rental_summary.key_money IS '礼金';
        COMMENT ON COLUMN rental_summary.address_street_part IS '所在地（何丁目まで）';
        COMMENT ON COLUMN rental_summary.address_number_part IS '所在地（何番から）';
        COMMENT ON COLUMN rental_summary.station1_name IS '駅1の名前';
        COMMENT ON COLUMN rental_summary.station1_bus_min IS '駅1までの所要時間（バス）';
        COMMENT ON COLUMN rental_summary.station1_walk_min IS '駅1までの所要時間（徒歩）';
        COMMENT ON COLUMN rental_summary.station1_car_time IS '駅1までの所要時間（車）';
        COMMENT ON COLUMN rental_summary.station2_name IS '駅2の名前';
        COMMENT ON COLUMN rental_summary.station2_bus_min IS '駅2までの所要時間（バス）';
        COMMENT ON COLUMN rental_summary.station2_walk_min IS '駅2までの所要時間（徒歩）';
        COMMENT ON COLUMN rental_summary.station2_car_time IS '駅2までの所要時間（車）';
        COMMENT ON COLUMN rental_summary.station3_name IS '駅3の名前';
        COMMENT ON COLUMN rental_summary.station3_bus_min IS '駅3までの所要時間（バス）';
        COMMENT ON COLUMN rental_summary.station3_walk_min IS '駅3までの所要時間（徒歩）';
        COMMENT ON COLUMN rental_summary.station3_car_time IS '駅3までの所要時間（車）';
        COMMENT ON COLUMN rental_summary.property_category IS '物件種目';
        COMMENT ON COLUMN rental_summary.structure_material IS '構造・材質';
        COMMENT ON COLUMN rental_summary.floor_plan_type IS '間取り';
        COMMENT ON COLUMN rental_summary.above_ground_floors IS '階層（地上）';
        COMMENT ON COLUMN rental_summary.below_ground_floors IS '階層（地下）';
        COMMENT ON COLUMN rental_summary.current_floor IS '所在階';
        COMMENT ON COLUMN rental_summary.construction_date IS '築年月';
        COMMENT ON COLUMN rental_summary.exclusive_area IS '専有面積';
        COMMENT ON COLUMN rental_summary.building_name IS '建物名';
        COMMENT ON COLUMN rental_summary.exterior_photo IS '建物外観画像（URL）';
        COMMENT ON COLUMN rental_summary.floor_plan_image IS '間取り図面（URL）';
        COMMENT ON COLUMN rental_summary.recommend IS '推薦物件';
        """;

        ChatMessageList.Add(ChatMessage.CreateSystemMessage(systemPrompt));
    }

    public Task ProcessRecommendAsync(List<String> recommendList, Func<String, Task> messageProcessor)
    {
        throw new NotImplementedException();
    }

    public async Task PostChatMessageAsync(String message, Func<String, Task> messageProcessor, Func<String, Task> shellMover)
    {
        var client = new ChatClient(modelaName, apiKey);

        ChatMessageList.Add(message);

        var clientResult = await client.CompleteChatAsync(ChatMessageList);

        if (clientResult.Value == null)
        {
            return;
        }

        ChatCompletion chatCompletion = clientResult;

        String responseMessage = String.Join(String.Empty, chatCompletion.Content
            .Select(chatMessageContentPart => chatMessageContentPart.Text)).Trim();

        if (chatCompletion.Role == ChatMessageRole.Assistant)
        {
            ChatMessageList.Add(ChatMessage.CreateAssistantMessage(responseMessage));
        }

        if (responseMessage.StartsWith(markdownPrefix) && responseMessage.EndsWith(markdownSuffix))
        {
            int startIndex = markdownPrefix.Length;
            int sqlLength = responseMessage.Length - markdownPrefix.Length - markdownSuffix.Length;

            var rawSQL = responseMessage.Substring(startIndex, sqlLength);

            await shellMover?.Invoke(rawSQL);

            return;
        }

        await messageProcessor?.Invoke($"{chatCompletion.Role}: {responseMessage}");
    }
}