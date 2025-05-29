using AIRE_App.Interfaces;
using AIRE_App.Services;
using AIRE_App.ViewModels;

namespace AIRE_App.Views;

public partial class AIChatView : ContentPage
{
    private readonly IAIService sqlAIService;

    private readonly AIStatusViewModel aiStatusViewModel;

    public AIChatView(AIStatusViewModel aiStatusViewModel,
        [FromKeyedServices(App.SqlAIServiceKey)] IAIService sqlAIService)
    {
        InitializeComponent();

        this.sqlAIService = sqlAIService;

        BindingContext = this.aiStatusViewModel = aiStatusViewModel;
    }

    private async Task GoToList(String rawSQL)
    {
        await Shell.Current.GoToAsync("Rental/List?sqlModel=True", new Dictionary<String, Object>
        {
            { "rawSQL", rawSQL }
        });
    }

    private async void OnClicked_PostMessage(Object sender, EventArgs eventArgs)
    {
        if (String.IsNullOrWhiteSpace(aiStatusViewModel.UserMessage))
        {
            return;
        }

        var message = aiStatusViewModel.UserMessage;

        aiStatusViewModel.UserMessage = String.Empty;

        var messageViewModel = new MessageViewModel()
        {
            Role = "user",
            Text = message
        };

        aiStatusViewModel.MessageHistory.Add(messageViewModel);

        JSONService.AppendMessage(messageViewModel);

        aiStatusViewModel.MessageReceived = false;

        await sqlAIService.PostChatMessageAsync(message, response =>
        {
            aiStatusViewModel.AssistantMessage = response.Text;

            aiStatusViewModel.MessageHistory.Add(response);

            JSONService.AppendMessage(response);

            aiStatusViewModel.MessageReceived = true;

            return Task.CompletedTask;

        }, GoToList);
    }
}