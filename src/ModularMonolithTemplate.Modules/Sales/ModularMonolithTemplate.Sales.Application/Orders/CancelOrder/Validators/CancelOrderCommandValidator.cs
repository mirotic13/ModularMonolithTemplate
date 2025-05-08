using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.CancelOrder.Validators;

public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}