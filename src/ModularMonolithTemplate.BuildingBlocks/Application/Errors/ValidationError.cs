namespace ModularMonolithTemplate.BuildingBlocks.Application.Errors;

public sealed record ValidationError(string Field, string FieldMessage)
    : Error("VALIDATION_ERROR", $"[{Field}] {FieldMessage}");
