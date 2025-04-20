using AIRE_App.Interfaces;
using AIRE_App.Services.AIServices;
using AIRE_App.ViewModels;
using CommunityToolkit.Maui;
using Fonts;
using Microsoft.Extensions.Logging;

namespace AIRE_App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<AIStatusViewModel>();

        builder.Services.AddKeyedSingleton<IAIService, SqlAIService>("SqlAIService");
        builder.Services.AddKeyedSingleton<IAIService, ChatAIService>("ChatAIService");

        return builder.Build();
    }
}
