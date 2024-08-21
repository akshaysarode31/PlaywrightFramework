using Allure.NUnit.Attributes;
using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Interface;
using PlaywrightFramework.Pages;

namespace OrangeHrm.Pages
{
    public class LoginPage(IBrowserWrapper browserWrapper) : BasePage(browserWrapper, "Selectors")
    {
        [AllureStep("Navigate To Async")]
        public async Task NavigateToAsync()
        {
            await BrowserWrapper.NavigateToAsync($"{Configuration["AppSettings:BaseUrl"]}");
        }

        [AllureStep("Login Async")]
        public async Task LoginAsync()
        {
            var username = Configuration["User:Username"];
            var password = Configuration["User:Password"];

            await FillAsync("LoginForm", "UsernameInput", username);
            await FillAsync("LoginForm", "PasswordInput", password);
            await ClickAsync("LoginForm", "LoginButton");
        }

        [AllureStep("Is Logged In Async")]
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
