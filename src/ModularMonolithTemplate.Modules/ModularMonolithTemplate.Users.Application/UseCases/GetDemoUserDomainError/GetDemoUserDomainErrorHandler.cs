using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Errors;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;

public class GetDemoUserDomainErrorHandler : IRequestHandler<GetDemoUserDomainErrorQuery, BaseResponse<GetDemoUserDomainErrorResponse>>
{
    public Task<BaseResponse<GetDemoUserDomainErrorResponse>> Handle(GetDemoUserDomainErrorQuery request, CancellationToken cancellationToken)
    {
        var user = new GetDemoUserDomainErrorResponse("1", "Demo User", "demo@example.com");

        if (!user.IsActive)
        {
            return Task.FromResult(BaseResponse<GetDemoUserDomainErrorResponse>.Fail(new DomainError("User is inactive")));
        }

        return Task.FromResult(BaseResponse<GetDemoUserDomainErrorResponse>.Ok(user));
    }
}
