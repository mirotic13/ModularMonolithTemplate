namespace ModularMonolithTemplate.SharedKernel.Application.Responses;

public sealed class Error
{
    public string Code { get; }
    public string Message { get; }

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new("None", string.Empty);
    public static Error Validation(string message) => new("Validation", message);
    public static Error NotFound(string message) => new("NotFound", message);
    public static Error Unexpected(string message) => new("Unexpected", message);
    public static Error Domain(string message) => new("Domain", message);
    public static Error Unauthorized(string message) => new("Unauthorized", message);

    public static Error Custom(string code, string message) => new(code, message);
}
