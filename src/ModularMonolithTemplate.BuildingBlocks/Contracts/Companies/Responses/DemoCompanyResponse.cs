namespace ModularMonolithTemplate.BuildingBlocks.Contracts.Companies.Responses;

public record DemoCompanyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
