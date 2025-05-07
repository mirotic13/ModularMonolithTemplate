using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Sales.Application;
using ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.SharedKernel.Infraestructure.DependencyInjection;

namespace ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection;

public static class SalesModule
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureValidations();

        services.AddSharedKernel<IAssemblyMarker>();
        services.AddHttpContextAccessor();

        return services;
    }
}