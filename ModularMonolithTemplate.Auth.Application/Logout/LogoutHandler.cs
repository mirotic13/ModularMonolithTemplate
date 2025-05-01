using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Logout
{
    public class LogoutHandler(IAuthService authService) : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly IAuthService _authService = authService;

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _authService.LogoutAsync();
            return Unit.Value;
        }
    }
}
