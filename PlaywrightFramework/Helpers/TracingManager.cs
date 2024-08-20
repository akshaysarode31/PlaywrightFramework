using Microsoft.Playwright;

namespace PlaywrightFramework.Helpers
{
    public class TracingManager(IBrowserContext context, bool isTracingEnabled)
    {
        private readonly IBrowserContext _context = context;
        private readonly bool _isTracingEnabled = isTracingEnabled;

        public async Task StartTracingAsync()
        {
            if (_isTracingEnabled)
            {
                await _context.Tracing.StartAsync(new TracingStartOptions
                {
                    Screenshots = true,
                    Snapshots = true,
                    Sources = true
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