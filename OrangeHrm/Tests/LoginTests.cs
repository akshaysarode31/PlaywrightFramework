using NUnit.Framework.Internal;
using OrangeHrm.Pages;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Tests;

namespace OrangeHrm.Tests
{
    [TestFixture]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTests : TestSetup
    {
        //private IBrowserWrapper BrowserWrappers;

        [SetUp]
        public async Task SetUp()
        {
           /* BrowserWrappers = await PlaywrightFramework.Helpers.BrowserWrapper.CreateAsync(BrowserConfig);*/
        }

        [TearDown]
        public async Task TearDown()
        {
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

            // Clean up resources
            await BrowserWrappers.DisposeAsync();*/
        }

        [Test]
        public async Task TestSuccessfulLogin()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        public async Task TestSuccessfulLogin1()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin2()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin3()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin4()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin5()
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
        public async Task TestSuccessfulLogin7()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin8()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin9()
        {
            var loginPage = new LoginPage(BrowserWrappers, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
    }
}
