using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace OrangeHrm.Pages
{
    public class LoginPage(IBrowserWrapper browserWrapper, IConfiguration configuration) : BasePage(browserWrapper, configuration, "Selectors")
    {
        public async Task NavigateToAsync()
        {
            await BrowserWrapper.NavigateToAsync($"{Configuration["AppSettings:BaseUrl"]}");
        }

        public async Task LoginAsync()
        {
            var username = Configuration["User:Username"];
            var password = Configuration["User:Password"];

            await FillAsync("LoginForm", "UsernameInput", username);
            await FillAsync("LoginForm", "PasswordInput", password);
            await ClickAsync("LoginForm", "LoginButton");
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return await IsVisibleAsync("Dashboard", "DashboardLabel");
        }

        public async Task<string> GetLoggedInUserNameAsync()
        {
            return await GetTextContentAsync("Dashboard", "AccountName");
        }
    }
}
