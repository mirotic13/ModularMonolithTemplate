using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.Companies.Application.Configuration;
using ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection.Extensions;

namespace ModularMonolithTemplate.Companies.Infraestructure.DependencyInjection;

public static class CompaniesModule
{
    public static IServiceCollection AddCompaniesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureHandlers<AssemblyReference>()
            .ConfigureExceptionHandler()
            .ConfigureLogger();

        return services;
    }
}
