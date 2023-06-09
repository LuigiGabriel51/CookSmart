﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace CookSmart;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
//#if ANDROID
//        builder.Services.AddTransient<IServicesTeste, DemoServices>();
//        builder.Services.AddTransient<MainActivity>();
//#endif
        builder
            .UseMauiApp<App>()
            .UseLocalNotification()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "fa-solid");
                fonts.AddFont("fa-brands-400.ttf", "fa-brands");
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
