using FluentValidation;
using MediatR;
using Serilog;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.BuildingBlocks.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count == 0)
            return await next();

        Log.Warning("Validation failed for {Request}: {@Errors}", typeof(TRequest).Name, failures);

        var structuredErrors = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToList()
            );

        var responseType = typeof(TResponse);

        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(BaseResponse<>))
        {
            var dataType = responseType.GetGenericArguments()[0];

            var failMethod = typeof(BaseResponse<>)
                .MakeGenericType(dataType)
                .GetMethod(nameof(BaseResponse<object>.Fail), new[] { typeof(Dictionary<string, List<string>>) });

            if (failMethod != null)
            {
                var failResponse = failMethod.Invoke(null, new object[] { structuredErrors });
                return (TResponse)failResponse!;
            }
        }

        throw new InvalidOperationException($"Cannot construct validation failure response for type {responseType}");
    }
}
