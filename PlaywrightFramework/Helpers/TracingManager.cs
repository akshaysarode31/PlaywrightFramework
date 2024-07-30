using Microsoft.Playwright;

namespace PlaywrightFramework.Helpers
{
    public class TracingManager
    {
        private readonly IBrowserContext _context;
        private readonly bool _isTracingEnabled;

        public TracingManager(IBrowserContext context, bool isTracingEnabled)
        {
            _context = context;
            _isTracingEnabled = isTracingEnabled;
        }

        public async Task StartTracingAsync()
        {
            if (_isTracingEnabled)
            {
                await _context.Tracing.StartAsync(new TracingStartOptions
                {
                    Screenshots = true,
                    Snapshots = true
                });
            }
        }

        public async Task StopTracingAsync(string tracePath)
        {
            if (_isTracingEnabled)
            {
                await _context.Tracing.StopAsync(new TracingStopOptions
                {
                    Path = tracePath
                });
            }
        }
    }
}
