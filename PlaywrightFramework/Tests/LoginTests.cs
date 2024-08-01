using NUnit.Framework.Internal;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {

        [Test]
        public async Task TestSuccessfulLogin()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }

        [Test]
        public async Task TestSuccessfulLogin1()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin2()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin3()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin4()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin5()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin6()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin7()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin8()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
        [Test]
        public async Task TestSuccessfulLogin9()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);
            await loginPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }

    }
}
