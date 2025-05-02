namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserDomainError;

public record GetDemoUserDomainErrorResponse(string Id, string FullName, string Email, bool IsActive = false);