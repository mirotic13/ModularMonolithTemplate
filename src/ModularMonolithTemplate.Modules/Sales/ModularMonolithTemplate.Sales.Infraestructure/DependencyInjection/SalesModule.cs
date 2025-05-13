using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Sales.Application;
using ModularMonolithTemplate.SharedKernel.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Outbox.Infrastructure;
using ModularMonolithTemplate.Sales.Infrastructure.DependencyInjection.Extensions;
using ModularMonolithTemplate.Sales.Infrastructure.Persistence;

namespace ModularMonolithTemplate.Sales.Infrastructure.DependencyInjection;

public static class SalesModule
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDatabase(configuration)
            .ConfigureValidations();

        services.AddSharedKernel<IAssemblyMarker>();
        services.AddHttpContextAccessor();
        services.AddOutbox<SalesDbContext>();

        return services;
    }

    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SalesDbContext>();
        await SalesDbInitializer.InitializeAsync(context);
    }
}