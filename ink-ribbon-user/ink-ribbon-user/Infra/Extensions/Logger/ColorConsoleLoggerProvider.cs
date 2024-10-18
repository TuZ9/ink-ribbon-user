using System.Collections.Concurrent;

namespace ink_ribbon_user.Infra.Extensions.Logger
{
    public sealed class ColorConsoleLoggerProvider : ILoggerProvider
    {
        private readonly IDisposable? _onChangeToken;
        private ColorConsoleLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, ColorConsoleLogger> _logger = new(StringComparer.OrdinalIgnoreCase);

        public ILogger CreateLogger(string categoryName) => _logger.GetOrAdd(categoryName, name => ColorConsoleLogger(name, GetCurrentConfig));

        private ColorConsoleLogger ColorConsoleLogger(string name, Func<ColorConsoleLoggerConfiguration> getCurrentConfig)
        {
            throw new NotImplementedException();
        }

        private ColorConsoleLoggerConfiguration GetCurrentConfig() => _currentConfig;   

        public void Dispose()
        {
            _logger.Clear();
            _onChangeToken?.Dispose();
        }
    }
}
