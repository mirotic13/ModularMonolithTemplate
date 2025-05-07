using FluentValidation;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Commands;

namespace ModularMonolithTemplate.Auth.Application.Auth.Logout.Validators;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        // No props en LogoutCommand -> no validación necesaria
        // Se incluye por simetría y extensibilidad
    }
}