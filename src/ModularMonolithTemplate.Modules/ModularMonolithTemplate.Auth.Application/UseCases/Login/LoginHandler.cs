using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;
using ModularMonolithTemplate.BuildingBlocks.Logging;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Login;

public class LoginHandler(IAuthService authService, ILogService<LoginHandler> logger) : IRequestHandler<LoginCommand, BaseResponse<LoginResponse>>
{
    private readonly IAuthService _authService = authService;
    private readonly ILogService<LoginHandler> _logger = logger;

    public async Task<BaseResponse<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;
        _logger.Info($"Trying to log in as {request.Email}");

        var result = await _authService.LoginAsync(request.Email, request.Password);

        if (!result.Success)
        {
            _logger.Warn($"Login failed for {request.Email}");
            return BaseResponse<LoginResponse>.Fail("Invalid credentials");
        }

        _logger.Info($"Login successful for {request.Email}");
        return BaseResponse<LoginResponse>.Ok(result, "Login successful");
    }
}
