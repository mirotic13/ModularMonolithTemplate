namespace ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Requests;

public record RegisterRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; }
}
