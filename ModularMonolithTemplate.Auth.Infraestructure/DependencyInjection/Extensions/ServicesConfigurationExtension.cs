using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Contracts;
using ModularMonolithTemplate.Auth.Infraestructure.Services;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class ServicesConfigurationExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
