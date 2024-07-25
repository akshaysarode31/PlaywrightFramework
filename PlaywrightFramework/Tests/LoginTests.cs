using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTests : BaseTest
    {

        [Test]
        public async Task TestSuccessfulLogin()
        {
            var loginPage = new LoginPage(BrowserWrapper, Configuration);

            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(Configuration["Username"]);

            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
    }

}
