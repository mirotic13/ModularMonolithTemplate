using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.MarkAsPaid.Commands;

namespace ModularMonolithTemplate.Sales.Application.Orders.MarkAsPaid.Validators;

public class MarkOrderAsPaidCommandValidator : AbstractValidator<MarkOrderAsPaidCommand>
{
    public MarkOrderAsPaidCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}
