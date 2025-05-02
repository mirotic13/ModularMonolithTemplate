using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Errors;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

public class GetDemoUserValidationErrorHandler : IRequestHandler<GetDemoUserValidationErrorQuery, BaseResponse<GetDemoUserValidationErrorResponse>>
{
    public Task<BaseResponse<GetDemoUserValidationErrorResponse>> Handle(GetDemoUserValidationErrorQuery request, CancellationToken cancellationToken)
    {
        var user = new GetDemoUserValidationErrorResponse("1", "Demo User");

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            return Task.FromResult(BaseResponse<GetDemoUserValidationErrorResponse>.Fail(new ValidationError("Email", "Email is required")));
        }

        return Task.FromResult(BaseResponse<GetDemoUserValidationErrorResponse>.Ok(user));
    }
}
