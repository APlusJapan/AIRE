using AIRE_App.ViewModels;

namespace AIRE_App.Interfaces;

public interface IAIService
{
    public void SetID(String id);

    public void SetPrompt(String initPrompt, String extraPrompt);

    public Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor);

    public Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover);
}