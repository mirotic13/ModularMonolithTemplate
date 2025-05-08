using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.ShipOrder.Validators;

public class ShipOrderCommandValidator : AbstractValidator<ShipOrderCommand>
{
    public ShipOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}