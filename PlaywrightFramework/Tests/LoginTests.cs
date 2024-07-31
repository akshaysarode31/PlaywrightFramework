using NUnit.Framework.Internal;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
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
    }
}
