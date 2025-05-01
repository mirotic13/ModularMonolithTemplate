using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;
using ModularMonolithTemplate.BuildingBlocks.Logging;

namespace ModularMonolithTemplate.Auth.Application.Login;

public class LoginHandler(IAuthService authService, ILogService<LoginHandler> logger) : IRequestHandler<LoginCommand, bool>
{
    private readonly IAuthService _authService = authService;
    private readonly ILogService<LoginHandler> _logger = logger;

    public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        _logger.Info("Trying to log as " + request.Email);

        var result = await _authService.LoginAsync(request.Email, request.Password);

        if (!result)
        {
            _logger.Warn("Log failed for " + request.Email);
        }

        return result;
    }
}
