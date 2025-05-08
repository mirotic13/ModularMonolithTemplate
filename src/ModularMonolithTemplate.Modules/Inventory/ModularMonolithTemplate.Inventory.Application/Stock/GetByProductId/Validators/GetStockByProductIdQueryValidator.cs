using FluentValidation;
using ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Queries;

namespace ModularMonolithTemplate.Inventory.Application.Stock.GetByProductId.Validators;

public class GetStockByProductIdQueryValidator : AbstractValidator<GetStockByProductIdQuery>
{
    public GetStockByProductIdQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");
    }
}