using MediatR;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;

public class LoginDemoCommand : IRequest<Result<LoginDemoResponse>>
{
    public LoginDemoRequest Request { get; set; } = default!;
}
