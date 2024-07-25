using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace PlaywrightFramework.Helpers
{
    public static class BrowserHelper
    {
        public static async Task<IPage> GetNewPageAsync(IConfiguration configuration, bool headless = false)
        {
            try
            {
                var playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = headless
                });
                var context = await browser.NewContextAsync();
                var page = await context.NewPageAsync();
                return page;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create a new browser page.", ex);
            }
        }
    }
}
