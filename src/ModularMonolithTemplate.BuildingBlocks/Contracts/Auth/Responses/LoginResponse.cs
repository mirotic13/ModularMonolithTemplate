namespace ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;

public record LoginResponse
{
    public bool Success { get; set; }
    public string? Email { get; set; } = string.Empty;
}
