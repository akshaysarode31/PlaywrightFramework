using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Helpers
{
    public static class BrowserHelper
    {
        public static async Task<IPage> GetNewPageAsync(IConfiguration configuration, bool headless = true)
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
