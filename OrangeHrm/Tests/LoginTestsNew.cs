using NUnit.Framework.Internal;
using OrangeHrm.Pages;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Tests;

namespace OrangeHrm.Tests
{
    [TestFixture]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTestsNew : TestSetup
    {
        //private IBrowserWrapper BrowserWrappers;

        [SetUp]
        public async Task SetUp()
        {
            //BrowserWrappers = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(BrowserConfig);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Clean up resources

            /*if (BrowserConfig.TracingEnabled)
            {
                // Stop tracing and save the trace
                var traceFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmm}";
                var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{traceFileName}.zip");
                Console.WriteLine("Trace path is " + tracePath);
                await BrowserWrappers.StopTracingAsync(tracePath);
                // Add custom reporting logic if needed
                TestContext.AddTestAttachment(tracePath, $"{TestContext.CurrentContext.Test.Name + " Playwright Trace"}");
            }
            await BrowserWrappers.DisposeAsync();*/
        }

        [Test]
        public async Task TestSuccessfulLogin11()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        public async Task TestSuccessfulLogin12()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin22()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin32()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin42()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin52()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin6()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin72()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin82()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin92()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
    }
}
