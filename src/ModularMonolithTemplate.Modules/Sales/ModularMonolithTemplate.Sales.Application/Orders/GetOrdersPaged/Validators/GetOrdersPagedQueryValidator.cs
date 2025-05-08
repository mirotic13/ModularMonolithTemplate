using FluentValidation;
using ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Queries;

namespace ModularMonolithTemplate.Sales.Application.Orders.GetOrdersPaged.Validators;

public class GetOrdersPagedQueryValidator : AbstractValidator<GetOrdersPagedQuery>
{
    public GetOrdersPagedQueryValidator()
    {
        RuleFor(x => x.Request.Page)
            .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Request.PageSize)
            .InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100.");
    }
}
