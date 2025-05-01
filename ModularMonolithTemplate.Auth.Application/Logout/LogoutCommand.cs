using MediatR;

namespace ModularMonolithTemplate.Auth.Application.Logout
{
    public record LogoutCommand : IRequest<Unit>;
}
