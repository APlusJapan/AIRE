using AIRE_App.Interfaces;
using AIRE_App.Services.AIServices;
using AIRE_App.ViewModels;
using CommunityToolkit.Maui;
using Fonts;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;


namespace AIRE_App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                fonts.AddFont("MauiMaterialAssets.ttf", "MauiMaterialAssets");
                fonts.AddFont("MauiSampleFontIcon.ttf", "MauiSampleFontIcon");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<AIStatusViewModel>();

        builder.Services.AddKeyedSingleton<IAIService, SqlAIService>(App.sqlAIServiceKey);
        builder.Services.AddKeyedSingleton<IAIService, ChatAIService>(App.chatAIServiceKey);

        return builder.Build();
    }
}
