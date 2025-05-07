using FluentValidation;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Validators
{
    public class LoginDemoCommandValidator : AbstractValidator<LoginDemoCommand>
    {
        public LoginDemoCommandValidator()
        {
            RuleFor(x => x.Request.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email format is invalid");

            RuleFor(x => x.Request.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
