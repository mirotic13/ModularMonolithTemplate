using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Validators;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("Refresh token is required");
    }
}
