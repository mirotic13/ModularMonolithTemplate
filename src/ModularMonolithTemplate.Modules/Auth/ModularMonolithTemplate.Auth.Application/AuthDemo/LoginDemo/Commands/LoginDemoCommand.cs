using MediatR;
using ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Contracts;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.LoginDemo.Commands;

public class LoginDemoCommand : IRequest<LoginDemoResponse>
{
    public LoginDemoRequest Request { get; set; } = default!;
}
