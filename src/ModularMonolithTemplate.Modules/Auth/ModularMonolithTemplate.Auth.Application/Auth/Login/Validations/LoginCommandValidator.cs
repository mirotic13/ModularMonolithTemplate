using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Validations;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Request.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email format is invalid");

        RuleFor(x => x.Request.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
