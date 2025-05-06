using ModularMonolithTemplate.Auth.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Inventory.Infraestructure.DependencyInjection;
using ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection;

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
