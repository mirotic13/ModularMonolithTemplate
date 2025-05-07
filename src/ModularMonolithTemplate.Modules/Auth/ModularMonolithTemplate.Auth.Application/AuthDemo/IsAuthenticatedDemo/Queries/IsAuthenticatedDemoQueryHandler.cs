using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Contracts;
using ModularMonolithTemplate.SharedKernel.Application.Responses;

namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Queries;

public class IsAuthenticatedDemoQueryHandler(IHttpContextAccessor httpContextAccessor) : IRequestHandler<IsAuthenticatedDemoQuery, Result<IsAuthenticatedDemoResponse>>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Task<Result<IsAuthenticatedDemoResponse>> Handle(IsAuthenticatedDemoQuery request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        var email = user?.FindFirst(ClaimTypes.Name)?.Value;

        var response = new IsAuthenticatedDemoResponse
        {
            Email = email
        };

        return Task.FromResult(Result<IsAuthenticatedDemoResponse>.Success(response));
    }
}
