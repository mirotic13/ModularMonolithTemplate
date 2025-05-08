using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.AddItemToOrder.Validators;

public class AddItemToOrderCommandValidator : AbstractValidator<AddItemToOrderCommand>
{
    public AddItemToOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");

        RuleFor(x => x.Request.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(x => x.Request.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.Request.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("UnitPrice cannot be negative.");
    }
}