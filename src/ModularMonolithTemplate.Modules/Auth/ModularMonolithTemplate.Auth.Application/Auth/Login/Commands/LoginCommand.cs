using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public LoginRequest Request { get; set; } = default!;
}
