using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JheyPassword.Data.Configuration;

public static class DataDependencyInjectionConfig
{
    public static void AddDataDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPasswordRepository, PasswordRepository>();
    }
}