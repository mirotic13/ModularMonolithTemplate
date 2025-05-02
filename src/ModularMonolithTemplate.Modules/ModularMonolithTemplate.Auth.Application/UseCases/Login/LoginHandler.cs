using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Logging;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Login;

public class LoginHandler(IAuthService authService, ILogService<LoginHandler> logger) : IRequestHandler<LoginCommand, BaseResponse<bool>>
{
    private readonly IAuthService _authService = authService;
    private readonly ILogService<LoginHandler> _logger = logger;

    public async Task<BaseResponse<bool>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        _logger.Info($"Trying to log in as {request.Email}");

        var success = await _authService.LoginAsync(request.Email, request.Password);

        if (!success)
        {
            _logger.Warn($"Login failed for {request.Email}");
            return BaseResponse<bool>.Ok(false, "Invalid credentials");
        }

        _logger.Info($"Login successful for {request.Email}");
        return BaseResponse<bool>.Ok(true, "Login successful");
    }
}
