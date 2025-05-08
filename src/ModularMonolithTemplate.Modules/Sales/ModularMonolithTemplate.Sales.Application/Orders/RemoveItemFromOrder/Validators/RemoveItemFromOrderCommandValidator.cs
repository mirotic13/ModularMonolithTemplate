using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.RemoveItemFromOrder.Validators;

public class RemoveItemFromOrderCommandValidator : AbstractValidator<RemoveItemFromOrderCommand>
{
    public RemoveItemFromOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");

        RuleFor(x => x.OrderItemId)
            .NotEmpty().WithMessage("OrderItemId is required.");
    }
}