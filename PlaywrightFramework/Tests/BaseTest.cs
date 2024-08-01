using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

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
        }

        [TearDown]
        public async Task TearDown()
        {
            // Stop tracing and save the trace
            var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{TestContext.CurrentContext.Test.Name}.zip");
            await BrowserWrapper.StopTracingAsync(tracePath);

            // Clean up resources
            BrowserWrapper?.Dispose();

            // Add custom reporting logic if needed
            TestContext.AddTestAttachment(tracePath, "Playwright Trace");
        }
    }

}
