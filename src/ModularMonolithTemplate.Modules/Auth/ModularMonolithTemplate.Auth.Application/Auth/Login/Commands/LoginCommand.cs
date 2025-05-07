using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Login.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Login.Commands;

public class LoginCommand : IRequest<Result<LoginResponse>>
{
    public LoginRequest Request { get; set; } = default!;
}
