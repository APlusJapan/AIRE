using AIRE_App.ViewModels;

namespace AIRE_App.DataTemplates.TemplateSelector;

public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate UserTemplate { get; set; }

    public DataTemplate AssistantTemplate { get; set; }

    public MessageTemplateSelector()
    {
        UserTemplate = new DataTemplate(typeof(UserMessageTemplate));
        AssistantTemplate = new DataTemplate(typeof(AssistantMessageTemplate));
    }

    protected override DataTemplate OnSelectTemplate(Object item, BindableObject container)
    {
        DataTemplate dataTemplate = null;

        if (item is MessageViewModel messageViewModel)
        {
            switch(messageViewModel.Role)
            {
                case "user":
                    {
                        dataTemplate = UserTemplate;
                        break;
                    }
                case "assistant":
                    {
                        dataTemplate = AssistantTemplate;
                        break;
                    }
            }
        }

        return dataTemplate;
    }
}