using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.BuildingBlocks.Application.Behaviors;

namespace ModularMonolithTemplate.BuildingBlocks.DependencyInjection;

public static class ExceptionBehaviorConfigurationExtension
{
    public static IServiceCollection ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        return services;
    }
}
