using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using Allure.NUnit;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace PlaywrightFramework.Tests
{
    [AllureNUnit]
    public class TestSetup
    {
        public IConfiguration Configuration { get; private set; }
        public BrowserConfiguration BrowserConfig { get; private set; }
        public IBrowserWrapper BrowserWrapper { get; set; }

        [OneTimeSetUp]
        [AllureBefore("Cleanup Result Directory")]
        public void CleanupResultDirectory()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        [AllureBefore("Setup session")]
        public async Task GlobalSetup()
        {
            Configuration = ConfigurationLoader.LoadConfiguration();
            BrowserConfig = ConfigurationLoader.LoadBrowserConfig(Configuration);
            BrowserWrapper = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(BrowserConfig);
        }

        [TearDown]
        [AllureAfter("Dispose Session")]
        public async Task TearDown()
        {
            if (BrowserConfig.TracingEnabled)
            {
                // Stop tracing and save the trace
                var traceFileName = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmm}";
                var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory,"PlaywrightTraces",$"{traceFileName}.zip");
                Console.WriteLine("Trace path is " + tracePath);
                await BrowserWrapper.StopTracingAsync(tracePath);
            }
            await BrowserWrapper.DisposeAsync();
        }

        [OneTimeTearDown]
        [AllureAfter("Generate Allure Reports Dispose Session")]
        public async Task OneTimeTearDown()
        {
            

            // Clean up resources
            // Ensure all browser instances are closed
            if (BrowserWrapper != null)
            {
                await BrowserWrapper.DisposeAsync();
            }

            AllureReportGenerator.GenerateAllureReport();
            //AllureReportGenerator.OpenAllureReport();
        }
    }
}
