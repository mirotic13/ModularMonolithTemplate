using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Inventory.Infrastructure.DependencyInjection;
using ModularMonolithTemplate.Sales.Infrastructure.DependencyInjection;

namespace ModularMonolithTemplate.API.Configuration;

public static class ModulesConfiguration
{
    public static void ConfigureModules(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthModule(builder.Configuration)
            .AddInventoryModule(builder.Configuration)
            .AddSalesModule(builder.Configuration);
    }
}
