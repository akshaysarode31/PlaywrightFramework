using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PlaywrightFramework.Interface;

namespace PlaywrightFramework.Helpers
{
    public class BrowserWrapper : IBrowserWrapper
    {
        private readonly IBrowser _browser;
        private readonly IPage _page;
        private readonly IBrowserContext _context;
        private readonly TracingManager _tracingManager;

        public IPage Page => _page;
        public IBrowser Browser => _browser;
        public IBrowserContext Context => _context;

        private BrowserWrapper(IBrowser browser, IBrowserContext context, IPage page, TracingManager tracingManager)
        {
            _browser = browser;
            _context = context;
            _page = page;
            _tracingManager = tracingManager;
        }

        public static async Task<IBrowserWrapper> CreateAsync(BrowserConfiguration config)
        {
            //config = ConfigurationLoader.LoadBrowserConfig(ConfigurationLoader.LoadConfiguration());
            var playwright = await Playwright.CreateAsync();
            IBrowser browser;

            var browserLaunchers = new Dictionary<string, Func<BrowserTypeLaunchOptions, Task<IBrowser>>>
            {
                { "firefox", playwright.Firefox.LaunchAsync },
                { "webkit", playwright.Webkit.LaunchAsync },
                { "chromium", playwright.Chromium.LaunchAsync },
            };

            if (browserLaunchers.TryGetValue(config.BrowserName, out var launcher))
            {
                browser = await launcher(new BrowserTypeLaunchOptions { Headless = config.Headless, SlowMo = config.SlowMo });
            }
            else
            {
                throw new ArgumentException($"Unsupported browser: {config.BrowserName}");
            }

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = config.ViewportWidth,
                    Height = config.ViewportHeight
                },
            };

            var context = config.Incognito ? await browser.NewContextAsync(contextOptions) : await browser.NewContextAsync();
            var tracingManager = new TracingManager(context, config.TracingEnabled);
            if (config.TracingEnabled)
            {
                await tracingManager.StartTracingAsync();
            }
            var page = await context.NewPageAsync();
            page.SetDefaultTimeout(config.DefaultTimeout);
            return new BrowserWrapper(browser, context, page, tracingManager);
        }

        public async Task NavigateToAsync(string url)
        {
            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync();
        }

        public async Task FillAsync(Selector selector, string value)
        {
            var locator = GetLocator(selector.Type, selector.Value);
            await locator.FillAsync(value);
        }

        public async Task ClickAsync(Selector selector)
        {
            var locator = GetLocator(selector.Type, selector.Value);
            await locator.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task<bool> IsVisibleAsync(Selector selector)
        {
            var locator = GetLocator(selector.Type, selector.Value);
            await locator.WaitForAsync();
            return await locator.IsVisibleAsync();
        }

        public async Task<string> GetTextContentAsync(Selector selector)
        {
            var locator = GetLocator(selector.Type, selector.Value);
            return await locator.TextContentAsync();
        }

        public async Task StartTracingAsync()
        {
            await _tracingManager.StartTracingAsync();
        }

        public async Task StopTracingAsync(string tracePath)
        {
            await _tracingManager.StopTracingAsync(tracePath);
        }

        public ILocator GetLocator(string type, string value)
        {
            return type.ToLower() switch
            {
                "css" => _page.Locator(value),
                "xpath" => _page.Locator($"xpath={value}"),
                "text" => _page.Locator($"text={value}"),
                "id" => _page.Locator($"id={value}"),
                "placeholder" => _page.GetByPlaceholder(value),
                "alttext" => _page.GetByAltText(value),
                "label" => _page.GetByLabel(value),
                "title" => _page.GetByTitle(value),
                "testid" => _page.GetByTestId(value),
                _ => throw new ArgumentException($"Unknown locator type: {type}"),
            };
        }
        public void Dispose()
        {
            _page?.CloseAsync().GetAwaiter().GetResult();
            _context?.CloseAsync().GetAwaiter().GetResult();
            _browser?.CloseAsync().GetAwaiter().GetResult();
        }

        public async Task DisposeAsync()
        {
            _page?.CloseAsync().GetAwaiter().GetResult();
            _context?.CloseAsync().GetAwaiter().GetResult();
            _browser?.CloseAsync().GetAwaiter().GetResult();
            /*await _page.CloseAsync();
            await _context.CloseAsync();
            await _browser.CloseAsync();*/
        }
    }


}
