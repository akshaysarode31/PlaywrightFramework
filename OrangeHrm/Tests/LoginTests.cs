using NUnit.Framework.Internal;
using OrangeHrm.Pages;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Tests;

namespace OrangeHrm.Tests
{
    [TestFixture]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Self)]
    public class LoginTests : TestSetup
    {
        private LoginPage loginPage;

        [SetUp]
        public void Initliaze()
        {
            loginPage = new LoginPage(BrowserWrapper, Configuration);
        }

        [Test]
        public async Task TestSuccessfulLogin()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        public async Task Login_WithValidCredentials_ShouldNavigateToDashboard()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            await BrowserWrapper.Page.WaitForURLAsync("**/dashboard/index");
            Assert.That(BrowserWrapper.Page.Url, Is.EqualTo("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index"));
        }

        [Test]
        public async Task Login_WithInvalidCredentials_ShouldShowErrorMessage()
        {
            await loginPage.NavigateToAsync();
            await loginPage.FillAsync("LoginForm", "UsernameInput", "admin");
            await loginPage.FillAsync("LoginForm", "PasswordInput", "admiin ");
            await loginPage.ClickAsync("LoginForm", "LoginButton");
            var selector = loginPage.GetSelector("LoginForm", "ErrorMessage");
            string errorMessage = await BrowserWrapper.GetTextContentAsync(selector);
            Assert.That(errorMessage, Is.EqualTo("Invalid credentials"));
        }

        [Test]
        public async Task Login_WithEmptyCredentials_ShouldShowErrorMessage()
        {
            await loginPage.NavigateToAsync();
            await loginPage.FillAsync("LoginForm", "UsernameInput", "admin");
            await loginPage.FillAsync("LoginForm", "PasswordInput", "");
            await loginPage.ClickAsync("LoginForm", "LoginButton");
            var selector = loginPage.GetSelector("LoginForm", "RequiredMessage");
            string errorMessage = await BrowserWrapper.GetTextContentAsync(selector);
            Assert.That(errorMessage, Is.EqualTo("Required"));
        }

        [Test]
        public async Task TestSuccessfulLogin1()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin2()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin3()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin4()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task TestSuccessfulLogin5()
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
    }
}
