using OrangeHrm.Pages;
using PlaywrightFramework.Tests;
using Allure.NUnit.Attributes;

namespace OrangeHrm.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class DashboardTests : TestSetup
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [SetUp]
        [AllureBefore("Login to application")]
        public async Task Setup()
        {
            loginPage = new LoginPage(BrowserWrapper);
            dashboardPage = new DashboardPage(BrowserWrapper);
            //await loginPage.InitializeAsync();
            //await dashboardPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
        }

        [Test]
        [AllureName("Dashboard Label Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task DashboardLabel_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsDashboardLabelVisible();
            Assert.That(isVisible, Is.True, "Dashboard label is not visible");
        }

        [Test]
        [AllureName("Quick Launch Panel Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task QuickLaunchPanel_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsQuickLaunchPanelVisible();
            Assert.That(isVisible, Is.True, "Quick Launch Panel is not visible");
        }

        [Test]
        [AllureName(" Assign Leave Icon Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task AssignLeaveIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsAssignLeaveIconClickable();
            Assert.That(isClickable, Is.True, "Assign Leave Icon is not clickable");
        }

        [Test]
        [AllureName("leave List icon Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task LeaveListIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsLeaveListIconClickable();
            Assert.That(isClickable, Is.True, "Leave List Icon is not clickable");
        }

        [Test]
        [AllureName("Timesheet icon Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task TimesheetsIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsTimesheetsIconClickable();
            Assert.That(isClickable, Is.True, "Timesheets Icon is not clickable");
        }

        [Test]
        [AllureName("My Actions Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task MyActions_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsMyActionsVisible();
            Assert.That(isVisible, Is.True, "My Actions section is not visible");
        }

        [Test]
        [AllureName("Employee Distribution Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task EmployeeDistribution_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsEmployeeDistributionVisible();
            Assert.That(isVisible, Is.True, "Employee Distribution section is not visible");
        }

        [Test]
        [AllureName("Time At Work Should Be Visible")]
        [AllureTag("Smoke")]
        public async Task TimeAtWork_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsTimeAtWorkVisible();
            Assert.That(isVisible, Is.True, "Legend section is not visible");
        }
    }
}
