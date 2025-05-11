using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Validators;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Request.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email format is invalid");

        RuleFor(x => x.Request.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
