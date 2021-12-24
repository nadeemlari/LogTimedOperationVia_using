using System.Diagnostics;

namespace LogTimedOperationVia_using.Logging;

public class TimedLogOperation<T> : IDisposable
{
    private readonly ILogger<T> _logger;
    private readonly string _message;
    private readonly object?[] _arg;
    private readonly Stopwatch _stopwatch;
    public TimedLogOperation(ILogger<T> logger, string message, object?[] arg)
    {
        _logger = logger;
        _message = message;
        _arg = arg;
        _stopwatch = Stopwatch.StartNew();
    }
   
    public void Dispose()
    {
        _stopwatch.Stop();
        _logger.LogInformation($"{_message} executed in {_stopwatch.ElapsedMilliseconds}ms",_arg);
    }
}