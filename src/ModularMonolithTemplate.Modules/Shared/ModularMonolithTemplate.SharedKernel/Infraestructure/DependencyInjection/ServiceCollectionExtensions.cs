using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.SharedKernel.Application.Abstractions;
using ModularMonolithTemplate.SharedKernel.Application.Behaviors;
using ModularMonolithTemplate.SharedKernel.Infraestructure.DomainEvents;

namespace ModularMonolithTemplate.SharedKernel.Infraestructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedKernel<T>(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<T>());
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}