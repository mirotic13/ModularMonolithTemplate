using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUser;

public class GetDemoUserHandler : IRequestHandler<GetDemoUserQuery, BaseResponse<DemoUserResponse>>
{
    public Task<BaseResponse<DemoUserResponse>> Handle(GetDemoUserQuery query, CancellationToken cancellationToken)
    {
        var user = new DemoUserResponse 
        { 
            Id = "1",
            FullName = "Demo User", 
            Email = "demo@example.com"
        };
        return Task.FromResult(BaseResponse<DemoUserResponse>.Ok(user));
    }
}
