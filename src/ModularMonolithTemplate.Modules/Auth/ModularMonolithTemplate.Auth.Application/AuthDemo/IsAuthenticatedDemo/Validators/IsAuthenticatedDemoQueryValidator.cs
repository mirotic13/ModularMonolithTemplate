using FluentValidation;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Validators;

public class IsAuthenticatedDemoQueryValidator : AbstractValidator<IsAuthenticatedDemoQuery>
{
    public IsAuthenticatedDemoQueryValidator()
    {
        // No props en IsAuthenticatedDemoQueryValidator -> no validación necesaria
    }
}
