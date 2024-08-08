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
        private LoginPage loginPage;

        [SetUp]
        public async Task Initliaze()
        {
            loginPage = new LoginPage(BrowserWrapper, Configuration);
        }
        //private IBrowserWrapper BrowserWrapper;

        [SetUp]
        public async Task SetUp()
        {
            //BrowserWrapper = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(BrowserConfig);
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
                await BrowserWrapper.StopTracingAsync(tracePath);
                // Add custom reporting logic if needed
                TestContext.AddTestAttachment(tracePath, $"{TestContext.CurrentContext.Test.Name + " Playwright Trace"}");
            }
            await BrowserWrapper.DisposeAsync();*/
        }

        [Test]
        public async Task TestSuccessfulLogin11()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        public async Task TestSuccessfulLogin12()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin22()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin32()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin42()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin52()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin6()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin72()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin82()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin92()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
    }
}
