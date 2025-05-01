using MediatR;

namespace ModularMonolithTemplate.Auth.Application.Register;

public record RegisterCommand(string Email, string Password, string FullName) : IRequest<bool>;
