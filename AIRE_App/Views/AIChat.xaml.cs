using AIRE_App.ViewModels;

namespace AIRE_App.Views;

public partial class AIChatView : ContentPage
{
    public AIChatView(AIStatusViewModel aiStatusViewModel)
    {
        InitializeComponent();

        BindingContext = aiStatusViewModel;
    }
}