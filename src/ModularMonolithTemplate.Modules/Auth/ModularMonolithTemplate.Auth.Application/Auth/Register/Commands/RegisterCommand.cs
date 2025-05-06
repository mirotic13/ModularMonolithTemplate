using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Auth.Register.Commands;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public RegisterRequest Request { get; set; } = default!;
}
