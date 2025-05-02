using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Errors;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

public class GetDemoUserValidationErrorHandler : IRequestHandler<GetDemoUserValidationErrorQuery, BaseResponse<DemoUserValidationErrorResponse>>
{
    public Task<BaseResponse<DemoUserValidationErrorResponse>> Handle(GetDemoUserValidationErrorQuery request, CancellationToken cancellationToken)
    {
        var user = new DemoUserValidationErrorResponse 
        { 
            Id = "1",
            FullName = "Demo User"
        };

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            return Task.FromResult(BaseResponse<DemoUserValidationErrorResponse>.Fail(new ValidationError("Email", "Email is required")));
        }

        return Task.FromResult(BaseResponse<DemoUserValidationErrorResponse>.Ok(user));
    }
}
