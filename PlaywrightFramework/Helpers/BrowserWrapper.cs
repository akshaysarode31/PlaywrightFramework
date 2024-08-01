using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
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

        private BrowserWrapper(IBrowser browser, IBrowserContext context, IPage page, TracingManager tracingManager)
        {
            _browser = browser;
            _context = context;
            _page = page;
            _tracingManager = tracingManager;
        }

        public static async Task<IBrowserWrapper> CreateAsync(IConfiguration configuration)
        {
            var browserName = configuration["Browser:Name"];
            var headless = bool.Parse(configuration["Browser:Headless"]);
            var incognito = bool.Parse(configuration["Browser:Incognito"]);
            var viewportWidth = int.Parse(configuration["Browser:ViewportWidth"]);
            var viewportHeight = int.Parse(configuration["Browser:ViewportHeight"]);
            var slowMo = int.Parse(configuration["Browser:SlowMo"]);
            var tracingEnabled = bool.Parse(configuration["Browser:Tracing"]);

            var playwright = await Playwright.CreateAsync();
            IBrowser browser;

            // Using a dictionary for better readability and maintainability
            var browserLaunchers = new Dictionary<string, Func<BrowserTypeLaunchOptions, Task<IBrowser>>>
        {
            { "firefox", playwright.Firefox.LaunchAsync },
            { "webkit", playwright.Webkit.LaunchAsync },
            { "chromium", playwright.Chromium.LaunchAsync },
        };

            if (browserLaunchers.TryGetValue(browserName, out var launcher))
            {
                browser = await launcher(new BrowserTypeLaunchOptions { Headless = headless, SlowMo = slowMo });
            }
            else
            {
                throw new ArgumentException($"Unsupported browser: {browserName}");
            }

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = viewportWidth,
                    Height = viewportHeight
                }
            };

            var context = incognito ? await browser.NewContextAsync(contextOptions) : await browser.NewContextAsync();
            var tracingManager = new TracingManager(context, tracingEnabled);


            var page = await context.NewPageAsync();

            return new BrowserWrapper(browser, context, page, tracingManager);
        }

        public async Task NavigateToAsync(string url)
        {
            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
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

        public async Task StartTracingAsync(string traceName)
        {
            await _tracingManager.StartTracingAsync();
        }

        public async Task StopTracingAsync(string tracePath)
        {
            await _tracingManager.StopTracingAsync(tracePath);
        }

        private ILocator GetLocator(string type, string value)
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
            await _page.CloseAsync();
            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }


}
