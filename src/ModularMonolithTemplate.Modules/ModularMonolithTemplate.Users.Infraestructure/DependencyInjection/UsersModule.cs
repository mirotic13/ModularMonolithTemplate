using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.Users.Application.Configuration;
using ModularMonolithTemplate.Users.Infraestructure.DependencyInjection.Extensions;

namespace ModularMonolithTemplate.Users.Infraestructure.DependencyInjection;

public static class UsersModule
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureHandlers<AssemblyReference>()
            .ConfigureLogger();

        return services;
    }
}
