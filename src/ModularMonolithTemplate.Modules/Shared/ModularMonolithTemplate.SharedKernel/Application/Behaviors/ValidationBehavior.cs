using FluentValidation;
using MediatR;
using ModularMonolithTemplate.SharedKernel.Application.Responses;
using System.Reflection;

namespace ModularMonolithTemplate.SharedKernel.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next(cancellationToken);

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
        {
            var message = string.Join(" | ", failures.Select(f => f.ErrorMessage));

            var resultType = typeof(TResponse);
            if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var error = Error.Validation(message);
                var failureMethod = resultType.GetMethod("Failure", BindingFlags.Static | BindingFlags.Public);
                return (TResponse)failureMethod!.Invoke(null, [error])!;
            }

            throw new ValidationException(message);
        }

        return await next(cancellationToken);
    }
}
