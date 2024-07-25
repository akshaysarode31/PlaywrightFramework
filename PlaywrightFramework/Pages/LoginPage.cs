using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using System;
using System.Threading.Tasks;

namespace PlaywrightFramework.Pages
{
    public class LoginPage
    {
        private readonly BrowserWrapper _browserWrapper;
        private readonly IConfiguration _configuration;

        public LoginPage(BrowserWrapper browserWrapper, IConfiguration configuration)
        {
            _browserWrapper = browserWrapper ?? throw new ArgumentNullException(nameof(browserWrapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task NavigateToAsync()
        {
            await _browserWrapper.NavigateToAsync($"{_configuration["BaseUrl"]}");
        }

        public async Task LoginAsync(string username)
        {
            string password = _configuration["Password"];
            await _browserWrapper.HandleAuthenticationAsync(username, password);
            await _browserWrapper.FillAsync("input[name='username']", username);
            await _browserWrapper.FillAsync("input[name='password']", password);
            await _browserWrapper.ClickAsync("button[type='submit']");
            await _browserWrapper.Page.WaitForNavigationAsync();
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return await _browserWrapper.IsVisibleAsync("#account-name");
        }

        public async Task<string> GetLoggedInUserNameAsync()
        {
            return await _browserWrapper.GetTextContentAsync("#account-name");
        }
    }

}
