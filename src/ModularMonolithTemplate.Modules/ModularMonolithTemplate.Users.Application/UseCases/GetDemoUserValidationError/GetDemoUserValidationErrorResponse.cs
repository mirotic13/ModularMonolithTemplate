namespace ModularMonolithTemplate.Users.Application.UseCases.GetDemoUserValidationError;

public record GetDemoUserValidationErrorResponse(string Id, string FullName, string? Email = null);
