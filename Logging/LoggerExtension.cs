namespace LogTimedOperationVia_using.Logging;

public static class LoggerExtension
{
    public static IDisposable TimedOperation<T>(this ILogger<T> logger, string message, params object?[] args)
    {
        return new TimedLogOperation<T>(logger, message, args);
    }
}