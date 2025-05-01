using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Auth.Infraestructure.Identity;

namespace ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection.Extensions;

public static class IdentityConfigurationExtension
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

        return services;
    }
}
