using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Register.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Register.Commands;

public class RegisterCommand : IRequest<Result<RegisterResponse>>
{
    public RegisterRequest Request { get; set; } = default!;
}
