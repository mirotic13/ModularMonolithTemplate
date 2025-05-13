using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Validators;

namespace ModularMonolithTemplate.Inventory.Infrastructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtensions
{
    public static IServiceCollection ConfigureValidations(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<GetStockByProductIdQueryValidator>();

        return services;
    }
}
