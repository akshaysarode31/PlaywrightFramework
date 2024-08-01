using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;

namespace PlaywrightFramework.Tests
{
    public class BaseTest
    {
        protected IConfiguration Configuration { get; private set; }
        protected IBrowserWrapper BrowserWrapper { get; private set; }


        [SetUp]
        public async Task SetUp()
        {
            // Load configuration
            Configuration = ConfigurationLoader.LoadConfiguration();
            // Initialize the browser and page
            BrowserWrapper = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(Configuration);

            //Generating tracing file is tracing flag is enabled.
            var traceFileName = bool.Parse(Configuration["Browser:Tracing"]) ? $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.zip" : null;
            if (traceFileName != null)
            {
                await BrowserWrapper.StartTracingAsync(traceFileName);
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            // Clean up resources
            if (BrowserWrapper != null)
            {
                await BrowserWrapper.DisposeAsync();
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            var tracingEnabled = bool.Parse(Configuration["Browser:Tracing"]);
            if (tracingEnabled)
            {
                // Stop tracing and save the trace
                var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{TestContext.CurrentContext.Test.Name}.zip");
                await BrowserWrapper.StopTracingAsync(tracePath);
                // Add custom reporting logic if needed
                TestContext.AddTestAttachment(tracePath, "Playwright Trace");
            }
            // Ensure all browser instances are closed
            if (BrowserWrapper != null)
            {
                await BrowserWrapper.DisposeAsync();
            }
        }
    }

}
