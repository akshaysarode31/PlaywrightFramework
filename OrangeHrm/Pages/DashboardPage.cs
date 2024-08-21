using Allure.NUnit.Attributes;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace OrangeHrm.Pages
{
    public class DashboardPage(IBrowserWrapper browserWrapper) : BasePage(browserWrapper, "Selectors")
    {
        public async Task<bool> IsLoggedInAsync()
        {
            return await IsVisibleAsync("Dashboard", "DashboardLabel");
        }

        public async Task<string> GetLoggedInUserNameAsync()
        {
            return await GetTextContentAsync("Dashboard", "AccountName");
        }

        [AllureStep("Is Dashboard label visible")]
        public async Task<bool> IsDashboardLabelVisible()
        {
            return await IsVisibleAsync("Dashboard", "DashboardLabel");
        }

        [AllureStep("Is Quick Launch Panel icon visible")]
        public async Task<bool> IsQuickLaunchPanelVisible()
        {
            return await IsVisibleAsync("Dashboard", "QuickLaunchPanel");
        }
        [AllureStep("Is Assign leave icon visible")]
        public async Task<bool> IsAssignLeaveIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "AssignLeaveIcon") && await IsEnabledAsync("Dashboard", "AssignLeaveIcon");
        }

        [AllureStep("Is Leave list icon visible")]
        public async Task<bool> IsLeaveListIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "LeaveListIcon") && await IsEnabledAsync("Dashboard", "LeaveListIcon");
        }

        [AllureStep("Is Timesheet Icon visible")]
        public async Task<bool> IsTimesheetsIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "TimesheetsIcon") && await IsEnabledAsync("Dashboard", "TimesheetsIcon");
        }

        [AllureStep("Is My Actions visible")]
        public async Task<bool> IsMyActionsVisible()
        {
            return await IsVisibleAsync("Dashboard", "MyActions");
        }

        [AllureStep("Is Employee Distribution visible")]
        public async Task<bool> IsEmployeeDistributionVisible()
        {
            return await IsVisibleAsync("Dashboard", "EmployeeDistribution");
        }

        [AllureStep("Is Time At Work visible")]
        public async Task<bool> IsTimeAtWorkVisible()
        {
            return await IsVisibleAsync("Dashboard", "TimeAtWork");
        }
    }
}
