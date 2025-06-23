using System.Text.Json;
using AIRE_App.ViewModels;

namespace AIRE_App.Services;

public static class JSONService
{
    private const String messageFilename = "message.jsonl";

    private static readonly String messageFilePath = Path.Combine(FileSystem.AppDataDirectory, messageFilename);

    public static void InitMessage(AIStatusViewModel aiStatusViewModel)
    {
        try
        {
            using var streamReader = File.OpenText(messageFilePath);

            for (String jsonString = streamReader.ReadLine();
                jsonString != null;
                jsonString = streamReader.ReadLine())
            {
                var message = JsonSerializer.Deserialize<MessageViewModel>(jsonString);

                aiStatusViewModel.MessageHistory.Add(message);
            }
        }
        catch(FileNotFoundException)
        {
            // aiStatusViewModel.MessageHistory = [];
        }
    }

    public static void AppendMessage(MessageViewModel message)
    {
        using var streamWriter = File.AppendText(messageFilePath);

        var jsonString = JsonSerializer.Serialize(message);

        streamWriter.WriteLine(jsonString);
    }
}