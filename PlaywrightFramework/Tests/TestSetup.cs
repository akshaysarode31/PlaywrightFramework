using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;

namespace PlaywrightFramework.Tests
{
    //[SetUpFixture]
    public class TestSetup
    {
        public static IConfiguration Configuration { get; private set; }
        public static BrowserConfiguration BrowserConfig { get; private set; }
        public static IBrowserWrapper BrowserWrappers { get; set; }


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Configuration = ConfigurationLoader.LoadConfiguration();
            BrowserConfig = ConfigurationLoader.LoadBrowserConfig(Configuration);
            BrowserWrappers = PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(BrowserConfig);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            if (BrowserConfig.TracingEnabled)
            {
                // Stop tracing and save the trace
                var traceFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmm}";
                var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{traceFileName}.zip");
                Console.WriteLine("Trace path is " + tracePath);
                await BrowserWrappers.StopTracingAsync(tracePath);
                // Add custom reporting logic if needed
                TestContext.AddTestAttachment(tracePath, $"{TestContext.CurrentContext.Test.Name + " Playwright Trace"}");
            }

            // Clean up resources
            await BrowserWrappers.DisposeAsync();

            // Ensure all browser instances are closed
            if (BrowserWrappers != null)
            {
                await BrowserWrappers.DisposeAsync();
            }
        }
    }
}
