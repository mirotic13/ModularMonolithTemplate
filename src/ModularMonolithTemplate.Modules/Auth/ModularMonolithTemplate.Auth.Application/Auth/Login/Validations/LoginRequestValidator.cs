using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Validations;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email format is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
