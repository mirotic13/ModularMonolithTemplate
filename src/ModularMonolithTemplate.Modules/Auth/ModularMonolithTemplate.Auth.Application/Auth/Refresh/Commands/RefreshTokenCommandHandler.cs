using MediatR;
using ModularMonolithTemplate.Auth.Application.Auth.Refresh.Contracts;
using ModularMonolithTemplate.Auth.Application.Services;
using ModularMonolithTemplate.Auth.Domain.Entities;
using ModularMonolithTemplate.Auth.Domain.Repositories;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.Auth.Refresh.Commands;

public class RefreshTokenCommandHandler(IRefreshTokenRepository repository, ITokenService tokenService) : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private readonly IRefreshTokenRepository _repository = repository;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<Result<RefreshTokenResponse>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var tokenStr = command.Request.RefreshToken;
        var token = await _repository.GetValidRefreshTokenAsync(tokenStr, cancellationToken);
        if (token is null)
            return Result<RefreshTokenResponse>.Failure(Error.Unauthorized("Invalid or expired refresh token."));

        var user = await _repository.GetUserByIdAsync(token.UserId, cancellationToken);
        if (user is null)
            return Result<RefreshTokenResponse>.Failure(Error.Unauthorized("User not found."));

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

        var response = new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token
        };

        return Result<RefreshTokenResponse>.Success(response);
    }
}