using Microsoft.Extensions.Logging;

namespace ModularMonolithTemplate.BuildingBlocks.Logging;

public interface ILogService<T>
{
    void Info(string message);
    void Warn(string message);
    void Error(string message, Exception? ex = null);
}

public class LogService<T>(ILogger<T> logger) : ILogService<T>
{
    private readonly ILogger<T> _logger = logger;

    public void Info(string message) => _logger.LogInformation(message);
    public void Warn(string message) => _logger?.LogWarning(message);
    public void Error(string message, Exception? ex = null) => _logger?.LogError(message, ex);
}
