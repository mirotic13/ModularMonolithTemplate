using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;

public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
    public RefreshTokenRequest Request { get; set; } = default!;
}
