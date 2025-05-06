namespace ModularMonolithTemplate.Auth.Application.Exceptions;

public class TwoFactorRequiredException(string message = "Two-factor authentication is required.") : Exception(message)
{
}
