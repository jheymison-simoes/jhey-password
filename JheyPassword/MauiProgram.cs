using System.Reflection;
using Castle.DynamicProxy;
using JheyPassword.Application.AutoMapper;
using JheyPassword.Application.Configuration;
using JheyPassword.Application.Services;
using JheyPassword.Business.Attributes;
using JheyPassword.Configuration;
using JheyPassword.Data;
using JheyPassword.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MudBlazor.Services;

namespace JheyPassword
{
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
            builder.Services.AddMudServices();
            builder.Logging.AddDebug(); 
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddDataDependencies();
            builder.Services.AddApplicationDependencies();
            // builder.Services.AddInterceptServices();
           
            var app = builder.Build();

            var context = app.Services.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            return app;
        }
    }
}
