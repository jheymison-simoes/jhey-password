using JheyPassword.Application.Services;
using JheyPassword.Business.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JheyPassword.Application.Configuration;

public static class ApplicationDependencyInjection
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        //Singleton
        services.AddScoped<IControlErrorService, ControlErrorService>();

        services.AddScoped<ICreatePasswordService, CreatePasswordService>();
        services.AddScoped<IGetAllPasswordsService, GetAllPasswordsService>();
        services.AddScoped<IDeletePasswordService, DeletePasswordService>();
    }
}