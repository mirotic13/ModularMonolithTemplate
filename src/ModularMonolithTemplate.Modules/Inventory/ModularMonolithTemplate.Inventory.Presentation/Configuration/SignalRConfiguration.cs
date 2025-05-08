using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Inventory.Presentation.Events;

namespace ModularMonolithTemplate.Inventory.Presentation.Configuration
{
    public static class SignalRConfiguration
    {
        public static IServiceCollection AddInventoryModulePresentation(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(StockUpdatedDomainEventHandler).Assembly);
            });

            return services;
        }
    }
}
