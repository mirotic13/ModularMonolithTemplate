using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Outbox.Application.Notifications;
using ModularMonolithTemplate.Outbox.Presentation.Notifications;

namespace ModularMonolithTemplate.Outbox.Presentation.Configuration;

public static class SignalRConfiguration
{
    public static IServiceCollection AddOutboxModulePresentation(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddScoped<IOutboxAlertNotifier, SignalROutboxAlertNotifier>();

        return services;
    }
}
