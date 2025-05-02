namespace ModularMonolithTemplate.BuildingBlocks.Contracts.Users.Responses;

public record DemoUserResponse
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
