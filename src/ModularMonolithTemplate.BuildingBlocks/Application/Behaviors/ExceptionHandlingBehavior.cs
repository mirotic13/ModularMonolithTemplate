using MediatR;
using Serilog;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Application.Errors;

namespace ModularMonolithTemplate.BuildingBlocks.Application.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception in request {Request}", typeof(TRequest).Name);

            var responseType = typeof(TResponse);
            var isBaseResponse = responseType.IsGenericType &&
                                 responseType.GetGenericTypeDefinition() == typeof(BaseResponse<>);

            if (!isBaseResponse)
                throw;

            var resultType = responseType.GetGenericArguments()[0];
            var failMethod = typeof(BaseResponse<>)
                .MakeGenericType(resultType)
                .GetMethod(nameof(BaseResponse<object>.Fail), [typeof(Error)]);

            if (failMethod == null)
                throw new InvalidOperationException("BaseResponse.Fail method not found.");

            var failResponse = failMethod.Invoke(null, new object[] {
                new DomainError("An unexpected error occurred.")
            });

            return (TResponse)failResponse!;
        }
    }
}
