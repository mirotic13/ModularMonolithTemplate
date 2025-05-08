using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Queries;

namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrderById.Validators;

public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}
