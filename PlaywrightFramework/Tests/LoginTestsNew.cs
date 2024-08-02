using NUnit.Framework.Internal;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTestsNew : TestSetup
    {
        private IBrowserWrapper _browserWrapper;

        [SetUp]
        public async Task SetUp()
        {
            _browserWrapper = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(TestSetup.BrowserConfig);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Clean up resources

            if (BrowserConfig.TracingEnabled)
            {
                // Stop tracing and save the trace
                var traceFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmm}";
                var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{traceFileName}.zip");
                Console.WriteLine("Trace path is " + tracePath);
                await _browserWrapper.StopTracingAsync(tracePath);
                // Add custom reporting logic if needed
                TestContext.AddTestAttachment(tracePath, $"{TestContext.CurrentContext.Test.Name + " Playwright Trace"}");
            }
                await _browserWrapper.DisposeAsync();
        }

        [Test]
        public async Task TestSuccessfulLogin11()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        public async Task TestSuccessfulLogin12()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin22()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin32()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin42()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin52()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin6()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin72()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin82()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin92()
        {
            var loginPage = new LoginPage(_browserWrapper, TestSetup.Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
    }
}
