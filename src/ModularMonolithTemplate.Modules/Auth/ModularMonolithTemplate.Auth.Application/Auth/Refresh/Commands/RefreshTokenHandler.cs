using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;
using ModularMonolithTemplate.Auth.Application.Repositories;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Domain.Entities;

public class RefreshTokenCommandHandler(IRefreshTokenRepository repository, ITokenService tokenService) : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IRefreshTokenRepository _repository = repository;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var tokenStr = command.Request.RefreshToken;
        var token = await _repository.GetValidRefreshTokenAsync(tokenStr, cancellationToken) ?? throw new UnauthorizedAccessException("Invalid or expired refresh token");
        var user = await _repository.GetUserByIdAsync(token.UserId, cancellationToken) ?? throw new UnauthorizedAccessException("User not found");

        await _repository.RevokeAsync(token, cancellationToken);

        var roles = await _repository.GetUserRolesAsync(user.Id, cancellationToken);
        var accessToken = _tokenService.GenerateToken(user, roles, true);

        var newRefreshToken = new RefreshToken 
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _repository.AddAsync(newRefreshToken, cancellationToken);

        return new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token
        };
    }
}
