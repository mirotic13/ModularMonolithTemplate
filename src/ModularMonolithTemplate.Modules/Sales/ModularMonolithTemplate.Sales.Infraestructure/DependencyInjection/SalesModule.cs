using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Logging;
using ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection.Extensions;

namespace ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection;

public static class SalesModule
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            //.ConfigureHandlers<AssemblyReference>()
            .ConfigureExceptionHandler()
            .ConfigureLogger();

        return services;
    }
}