using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace OrangeHrm.Pages
{
    public class DashboardPage(IBrowserWrapper browserWrapper, IConfiguration configuration) : BasePage(browserWrapper, configuration, "Selectors")
    {
        public async Task<bool> IsLoggedInAsync()
        {
            return await IsVisibleAsync("Dashboard", "DashboardLabel");
        }

        public async Task<string> GetLoggedInUserNameAsync()
        {
            return await GetTextContentAsync("Dashboard", "AccountName");
        }

        public async Task<bool> IsDashboardLabelVisible()
        {
            return await IsVisibleAsync("Dashboard", "DashboardLabel");
        }

        public async Task<bool> IsQuickLaunchPanelVisible()
        {
            return await IsVisibleAsync("Dashboard", "QuickLaunchPanel");
        }

        public async Task<bool> IsAssignLeaveIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "AssignLeaveIcon") && await IsEnabledAsync("Dashboard", "AssignLeaveIcon");
        }

        public async Task<bool> IsLeaveListIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "LeaveListIcon") && await IsEnabledAsync("Dashboard", "LeaveListIcon");
        }

        public async Task<bool> IsTimesheetsIconClickable()
        {
            return await IsVisibleAsync("Dashboard", "TimesheetsIcon") && await IsEnabledAsync("Dashboard", "TimesheetsIcon");
        }

        public async Task<bool> IsMyActionsVisible()
        {
            return await IsVisibleAsync("Dashboard", "MyActions");
        }

        public async Task<bool> IsEmployeeDistributionVisible()
        {
            return await IsVisibleAsync("Dashboard", "EmployeeDistribution");
        }

        public async Task<bool> IsTimeAtWorkVisible()
        {
            return await IsVisibleAsync("Dashboard", "TimeAtWork");
        }
    }
}
