namespace AIRE_App.Interfaces;

public interface IAIService
{
    public Task ProcessRecommendAsync(List<String> recommendList, Func<String, Task> messageProcessor);

    public Task PostChatMessageAsync(String message, Func<String, Task> messageProcessor, Func<String, Task> shellMover);
}