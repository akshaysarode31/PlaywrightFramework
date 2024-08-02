using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Interface;

namespace PlaywrightFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IBrowserWrapper browserWrapper, IConfiguration configuration)
         : base(browserWrapper, configuration)
        {
        }

        public async Task InitializeAsync()
        {
            base.Initialize("Selectors");
        }

        public async Task NavigateToAsync()
        {
            var url = Configuration["AppSettings:BaseUrl"];
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
