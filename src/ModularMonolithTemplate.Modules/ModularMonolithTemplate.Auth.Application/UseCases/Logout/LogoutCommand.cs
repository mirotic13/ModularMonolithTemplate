using MediatR;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Logout;

public record LogoutCommand : IRequest<Unit>;
