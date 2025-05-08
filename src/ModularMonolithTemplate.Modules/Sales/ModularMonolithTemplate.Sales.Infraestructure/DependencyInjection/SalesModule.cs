using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Sales.Application;
using ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.Sales.Infraestructure.Persistence;
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

    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SalesDbContext>();
        await SalesDbInitializer.InitializeAsync(context);
    }
}