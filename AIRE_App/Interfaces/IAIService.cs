using AIRE_App.ViewModels;
using AIRE_DB.Models;

namespace AIRE_App.Interfaces;

public interface IAIService
{
    public String GetID();

    public void SetID(String id);

    public void SetPrompt(PromptMaster systemInitPrompt, PromptMaster businessInitPrompt, PromptMaster extraPrompt);

    public Task ProcessRecommendAsync(List<String> recommendList, Func<MessageViewModel, Task> messageProcessor);

    public Task PostChatMessageAsync(String message, Func<MessageViewModel, Task> messageProcessor, Func<String, Task> shellMover);
}