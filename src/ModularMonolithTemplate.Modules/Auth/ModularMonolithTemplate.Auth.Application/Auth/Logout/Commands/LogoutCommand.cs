using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Contracts;

namespace ModularMonolithTemplate.Modules.Auth.Application.Auth.Logout.Commands;

public class LogoutCommand : IRequest<LogoutResponse>
{
}
