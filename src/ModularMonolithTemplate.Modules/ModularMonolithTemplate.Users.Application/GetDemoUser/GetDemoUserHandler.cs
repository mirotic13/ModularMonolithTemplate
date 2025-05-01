using MediatR;

namespace ModularMonolithTemplate.Users.Application.GetDemoUser;

public class GetDemoUserHandler : IRequestHandler<GetDemoUserQuery, GetDemoUserResponse>
{
    public Task<GetDemoUserResponse> Handle(GetDemoUserQuery request, CancellationToken cancellationToken)
    {
        var user = new GetDemoUserResponse("1", "Demo User", "demo@example.com");
        return Task.FromResult(user);
    }
}
