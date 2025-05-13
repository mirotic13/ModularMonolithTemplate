using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.CreateOrder.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.MarkAsPaid.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Validators;
using ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Validators;

namespace ModularMonolithTemplate.Sales.Infrastructure.DependencyInjection.Extensions;

public static class ValidationConfigurationExtensions
{
    public static IServiceCollection ConfigureValidations(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>()
            .AddValidatorsFromAssemblyContaining<GetOrderByIdQueryValidator>()
            .AddValidatorsFromAssemblyContaining<GetOrdersPagedQueryValidator>()
            .AddValidatorsFromAssemblyContaining<MarkOrderAsPaidCommandValidator>()
            .AddValidatorsFromAssemblyContaining<CancelOrderCommandValidator>()
            .AddValidatorsFromAssemblyContaining<ShipOrderCommandValidator>()
            .AddValidatorsFromAssemblyContaining<RemoveItemFromOrderCommandValidator>()
            .AddValidatorsFromAssemblyContaining<DeleteOrderCommandValidator>()
            .AddValidatorsFromAssemblyContaining<GetOrdersByCustomerIdQueryValidator>();

        return services;
    }
}
