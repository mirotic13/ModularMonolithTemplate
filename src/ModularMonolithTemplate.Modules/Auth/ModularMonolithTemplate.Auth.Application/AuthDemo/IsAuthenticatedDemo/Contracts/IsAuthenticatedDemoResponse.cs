namespace ModularMonolithTemplate.Auth.Application.AuthDemo.IsAuthenticatedDemo.Contracts;

public class IsAuthenticatedDemoResponse
{
    public string Message { get; set; } = "You are authenticated (demo)";
    public string? Email { get; set; }
}
