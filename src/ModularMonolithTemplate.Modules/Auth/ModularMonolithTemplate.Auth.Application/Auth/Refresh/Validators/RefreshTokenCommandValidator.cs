using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;

namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Validators;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.Request.RefreshToken)
            .NotEmpty().WithMessage("Refresh token is required");
    }
}
