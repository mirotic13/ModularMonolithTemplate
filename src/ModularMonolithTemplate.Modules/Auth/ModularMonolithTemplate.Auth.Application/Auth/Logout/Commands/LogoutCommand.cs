using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Logout.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Logout.Commands;

public class LogoutCommand : IRequest<Result<LogoutResponse>>
{
}
