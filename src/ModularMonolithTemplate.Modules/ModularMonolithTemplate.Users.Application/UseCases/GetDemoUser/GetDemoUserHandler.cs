using MediatR;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUser;

public class GetDemoUserHandler : IRequestHandler<GetDemoUserQuery, BaseResponse<GetDemoUserResponse>>
{
    public Task<BaseResponse<GetDemoUserResponse>> Handle(GetDemoUserQuery request, CancellationToken cancellationToken)
    {
        var user = new GetDemoUserResponse("1", "Demo User", "demo@example.com");
        return Task.FromResult(BaseResponse<GetDemoUserResponse>.Ok(user));
    }
}
