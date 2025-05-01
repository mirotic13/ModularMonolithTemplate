using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;

namespace ModularMonolithTemplate.Auth.Application.Register;

public class RegisterHandler(IAuthService authService) : IRequestHandler<RegisterCommand, bool>
{
    private readonly IAuthService _authService = authService;

    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(request.Email, request.FullName, request.Password);
        return result;
    }
}
