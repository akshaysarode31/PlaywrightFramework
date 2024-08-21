using Allure.NUnit.Attributes;
using NUnit.Framework.Internal;
using OrangeHrm.Pages;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Tests;

namespace OrangeHrm.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class LoginTestsNew : TestSetup
    {
        private LoginPage loginPage;

        [SetUp]
        [AllureBefore("Initliaze Page")]
        public void Initliaze()
        {
            loginPage = new LoginPage(BrowserWrapper);
        }

        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin11()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }

        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin12()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin22()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin32()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin42()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin52()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin6()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin72()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin82()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        [AllureName("Test Successful Login")]
        [AllureTag("Smoke")]
        public async Task TestSuccessfulLogin92()
        {
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
    }
}
