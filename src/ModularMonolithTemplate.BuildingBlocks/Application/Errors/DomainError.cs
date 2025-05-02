namespace ModularMonolithTemplate.BuildingBlocks.Application.Errors;

public sealed record DomainError(string DomainMessage)
    : Error("DOMAIN_ERROR", DomainMessage);
