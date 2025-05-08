using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrder.Validators;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}