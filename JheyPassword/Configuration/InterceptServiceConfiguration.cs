using System.Reflection;
using Castle.DynamicProxy;
using JheyPassword.Application.Services;
using JheyPassword.Business.Attributes;

namespace JheyPassword.Configuration;

public static class InterceptServiceConfiguration
{
    public static void AddInterceptServices(this IServiceCollection services)
    {
        var proxyGenerator = new ProxyGenerator();
            
        foreach (var serviceDescriptor in services.ToList())
        {
            // Verifica se o serviço é uma interface e não está marcado com [NoIntercept]
            if (serviceDescriptor.ServiceType.IsInterface &&
                serviceDescriptor.ServiceType.GetCustomAttribute<NoInterceptAttribute>() == null &&
                (serviceDescriptor.ImplementationType == null ||
                 serviceDescriptor.ImplementationType.GetCustomAttribute<NoInterceptAttribute>() == null))
            {
                // Remove o serviço original
                services.Remove(serviceDescriptor);

                // Adiciona o proxy como substituto
                services.AddScoped(serviceDescriptor.ServiceType, provider =>
                {
                    var implementation = provider.GetRequiredService(serviceDescriptor.ImplementationType);
                    return proxyGenerator.CreateInterfaceProxyWithTarget(
                        serviceDescriptor.ServiceType,
                        implementation,
                        new InterceptorService()
                    );
                });
            }
        }

    }
}