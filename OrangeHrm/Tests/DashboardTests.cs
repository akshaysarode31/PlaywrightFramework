using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using OrangeHrm.Pages;
using PlaywrightFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightFramework.Tests;

namespace OrangeHrm.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DashboardTests : TestSetup
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [SetUp]
        public async Task Setup()
        {
            loginPage = new LoginPage(BrowserWrapper, Configuration);
            dashboardPage = new DashboardPage(BrowserWrapper, Configuration);
            //await loginPage.InitializeAsync();
            //await dashboardPage.InitializeAsync();
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync();
        }

        [Test]
        public async Task DashboardLabel_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsDashboardLabelVisible();
            Assert.That(isVisible, Is.True, "Dashboard label is not visible");
        }

        [Test]
        public async Task QuickLaunchPanel_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsQuickLaunchPanelVisible();
            Assert.That(isVisible, Is.True, "Quick Launch Panel is not visible");
        }

        [Test]
        public async Task AssignLeaveIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsAssignLeaveIconClickable();
            Assert.That(isClickable, Is.True, "Assign Leave Icon is not clickable");
        }

        [Test]
        public async Task LeaveListIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsLeaveListIconClickable();
            Assert.That(isClickable, Is.True, "Leave List Icon is not clickable");
        }

        [Test]
        public async Task TimesheetsIcon_ShouldBeClickable()
        {
            var isClickable = await dashboardPage.IsTimesheetsIconClickable();
            Assert.That(isClickable, Is.True, "Timesheets Icon is not clickable");
        }

        [Test]
        public async Task MyActions_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsMyActionsVisible();
            Assert.That(isVisible, Is.True, "My Actions section is not visible");
        }

        [Test]
        public async Task EmployeeDistribution_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsEmployeeDistributionVisible();
            Assert.That(isVisible, Is.True, "Employee Distribution section is not visible");
        }

        [Test]
        public async Task TimeAtWork_ShouldBeVisible()
        {
            var isVisible = await dashboardPage.IsTimeAtWorkVisible();
            Assert.That(isVisible, Is.True, "Legend section is not visible");
        }
    }
}
