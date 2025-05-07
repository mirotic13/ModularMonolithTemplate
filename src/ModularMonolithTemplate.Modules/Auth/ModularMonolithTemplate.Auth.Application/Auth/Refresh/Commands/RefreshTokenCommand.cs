using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;

public class RefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>
{
    public RefreshTokenRequest Request { get; set; } = default!;
}
