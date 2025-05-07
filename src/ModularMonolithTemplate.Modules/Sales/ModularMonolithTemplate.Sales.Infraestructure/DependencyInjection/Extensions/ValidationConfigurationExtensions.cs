using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Validators;

namespace ModularMonolithTemplate.Sales.Infraestructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtensions
{
    public static IServiceCollection ConfigureValidations(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();

        return services;
    }
}
