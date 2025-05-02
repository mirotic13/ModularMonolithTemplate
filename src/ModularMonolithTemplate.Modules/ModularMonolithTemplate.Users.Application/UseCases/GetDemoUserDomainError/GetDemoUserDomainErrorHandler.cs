using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Errors;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;

public class GetDemoUserDomainErrorHandler : IRequestHandler<GetDemoUserDomainErrorQuery, BaseResponse<DemoUserDomainErrorResponse>>
{
    public Task<BaseResponse<DemoUserDomainErrorResponse>> Handle(GetDemoUserDomainErrorQuery query, CancellationToken cancellationToken)
    {
        var user = new DemoUserDomainErrorResponse 
        { 
            Id = "1",
            FullName = "Demo User",
            Email = "demo@example.com"
        };

        if (!user.IsActive)
        {
            return Task.FromResult(BaseResponse<DemoUserDomainErrorResponse>.Fail(new DomainError("User is inactive")));
        }

        return Task.FromResult(BaseResponse<DemoUserDomainErrorResponse>.Ok(user));
    }
}
