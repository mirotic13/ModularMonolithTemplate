using MediatR;

namespace ModularMonolithTemplate.Auth.Application.Login;

public record LoginCommand(string Email, string Password) : IRequest<bool>;
