using MediatR;
using ModularMonolithTemplate.Auth.Application.Contracts;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.UseCases.Register;

public class RegisterHandler(IAuthService authService) : IRequestHandler<RegisterCommand, BaseResponse<bool>>
{
    private readonly IAuthService _authService = authService;

    public async Task<BaseResponse<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(request.Email, request.FullName, request.Password);
        return result 
            ? BaseResponse<bool>.Ok(result, "Registration successful")
            : BaseResponse<bool>.Fail("Registration failed");
    }
}
