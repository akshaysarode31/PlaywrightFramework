using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PlaywrightFramework.Helpers
{
    public class BrowserWrapper
    {
        public IPage Page { get; }

        public BrowserWrapper(IPage page)
        {
            Page = page ?? throw new ArgumentNullException(nameof(page));
            Page.Dialog += HandleDialog;
        }

        private async void HandleDialog(object sender, IDialog dialog)
        {
            try
            {
                await dialog.AcceptAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to handle dialog.", ex);
            }
        }

        public async Task NavigateToAsync(string url)
        {
            try
            {
                await Page.GotoAsync(url);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to navigate to {url}.", ex);
            }
        }

        public async Task ClickAsync(string selector)
        {
            try
            {
                await Page.ClickAsync(selector);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to click element {selector}.", ex);
            }
        }

        public async Task FillAsync(string selector, string text)
        {
            try
            {
                await Page.FillAsync(selector, text);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to fill element {selector} with text.", ex);
            }
        }

        public async Task<bool> IsVisibleAsync(string selector)
        {
            try
            {
                return await Page.IsVisibleAsync(selector);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to check visibility of element {selector}.", ex);
            }
        }

        public async Task HandleAuthenticationAsync(string username, string password)
        {
            try
            {
                /*Page.Request += async (sender, request) =>
                {
                    if (request.Url.Contains("your_authentication_endpoint"))
                    {
                        await request.ContinueAsync(new RequestOptions
                        {
                            Headers = new Dictionary<string, string>
                        {
                            { "Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}" }
                        }
                        });
                    }
                };*/

                await Page.SetExtraHTTPHeadersAsync(new Dictionary<string, string>
            {
                { "Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}" }
            });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to handle authentication.", ex);
            }
        }

        public async Task<string> GetTextContentAsync(string selector)
        {
            try
            {
                return await Page.TextContentAsync(selector);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get text content of element {selector}.", ex);
            }
        }
    }

}
