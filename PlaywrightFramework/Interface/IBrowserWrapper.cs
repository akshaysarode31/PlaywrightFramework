using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PlaywrightFramework.Helpers;

namespace PlaywrightFramework.Interface
{
    public interface IBrowserWrapper : IDisposable
    {
        IPage Page { get; }
        Task NavigateToAsync(string url);
        Task FillAsync(Selector selector, string value);
        Task ClickAsync(Selector selector);
        Task<bool> IsVisibleAsync(Selector selector);
        Task<string> GetTextContentAsync(Selector selector);
        Task StopTracingAsync(string tracePath);
        //Task<IBrowserWrapper> CreateAsync(IConfiguration configuration);
    }

}
