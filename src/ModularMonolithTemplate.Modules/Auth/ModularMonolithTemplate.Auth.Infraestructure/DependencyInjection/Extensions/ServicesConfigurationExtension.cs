using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Infraestructure.Services;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class ServicesConfigurationExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<ITokenService, TokenService>();

        return services;
    }
}
