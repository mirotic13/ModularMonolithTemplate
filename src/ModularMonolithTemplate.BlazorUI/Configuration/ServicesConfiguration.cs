using ModularMonolithTemplate.BlazorUI.Services;

namespace ModularMonolithTemplate.BlazorUI.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
