using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Users.Infraestructure.DependencyInjection;

namespace ModularMonolithTemplate.API.Configuration;

public static class ModulesConfiguration
{
    public static void ConfigureModules(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthModule(builder.Configuration)
            .AddCompaniesModule(builder.Configuration)
            .AddUsersModule(builder.Configuration);
    }
}
