using Microsoft.AspNetCore.Authorization;

namespace ModularMonolithTemplate.Auth.Application.Security;

public class RequireValidToken : IAuthorizationRequirement
{
}
