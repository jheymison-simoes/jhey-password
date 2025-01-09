using JheyPassword.Application.AutoMapper;
using JheyPassword.Application.Configuration;
using JheyPassword.Components.Shared;
using JheyPassword.Data;
using JheyPassword.Data.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Plugin.Maui.Biometric;

namespace JheyPassword;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        
        var defaultImpl = BiometricAuthenticationService.Default;
        builder.Services.AddSingleton(defaultImpl);
        
        InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        builder.Services.AddMudServices(config => 
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });
        builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddDataDependencies();
        builder.Services.AddApplicationDependencies();

        var app = builder.Build();

        var context = app.Services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();

        return app;
    }
}