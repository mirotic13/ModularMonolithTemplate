using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Queries;

namespace ModularMonolithTemplate.Sales.Application.Orders.DeleteOrderByCustomerId.Validators;

public class GetOrdersByCustomerIdQueryValidator : AbstractValidator<GetOrdersByCustomerIdQuery>
{
    public GetOrdersByCustomerIdQueryValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}