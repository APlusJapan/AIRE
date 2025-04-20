using AIRE_App.ViewModels;

namespace AIRE_App.Data.TemplateSelector;

public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate UserTemplate { get; set; }

    public DataTemplate AssistantTemplate { get; set; }

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