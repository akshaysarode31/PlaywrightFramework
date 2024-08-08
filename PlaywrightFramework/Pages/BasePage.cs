using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;


namespace PlaywrightFramework.Pages
{
    public abstract class BasePage
    {
        protected readonly IDictionary<string, IDictionary<string, Selector>> _selectors = new Dictionary<string, IDictionary<string, Selector>>();
        protected readonly IBrowserWrapper BrowserWrapper;
        protected readonly IConfiguration Configuration;

        protected BasePage(IBrowserWrapper browserWrapper, IConfiguration configuration, params string[] pageNames)
        {
            BrowserWrapper = browserWrapper ?? throw new ArgumentNullException(nameof(browserWrapper));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            // Automatically initialize selectors
            Initialize(pageNames);
        }

        public ILocator GetLocators(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            return BrowserWrapper.GetLocator(selector.Type, selector.Value);
        }

        public void Initialize(params string[] pageNames)
        {
            foreach (string pageName in pageNames)
            {
                if (string.IsNullOrEmpty(pageName))
                    throw new ArgumentNullException(nameof(pageName));

                var selectorsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "selectors", $"{pageName}.yaml");
                var pageSelectors = SelectorsLoader.LoadSelectors(selectorsPath);

                foreach (var selectorSet in pageSelectors)
                {
                    if (_selectors.ContainsKey(selectorSet.Key))
                    {
                        throw new ArgumentException($"Duplicate selector set '{selectorSet.Key}' found in '{pageName}.yaml'");
                    }
                    _selectors[selectorSet.Key] = selectorSet.Value;
                }
            }
        }

        public async Task FillAsync(string locatorSet, string selectorName, string value)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            await BrowserWrapper.FillAsync(selector, value);
        }

        public async Task ClickAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            await BrowserWrapper.ClickAsync(selector);
        }

        public async Task<bool> IsVisibleAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            return await BrowserWrapper.IsVisibleAsync(selector);
        }
        public async Task<bool> IsEnabledAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            return await GetLocators(locatorSet, selectorName).IsEnabledAsync();
        }

        public async Task<string> GetTextContentAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            return await BrowserWrapper.GetTextContentAsync(selector);
        }

        public Selector GetSelector(string locatorSet, string selectorName)
        {
            if (_selectors.TryGetValue(locatorSet, out var selectors))
            {
                if (selectors.TryGetValue(selectorName, out var selector))
                {
                    return selector;
                }
                else
                {
                    throw new ArgumentException($"Selector '{selectorName}' not found in set '{locatorSet}'.");
                }
            }
            else
            {
                throw new ArgumentException($"Locator set '{locatorSet}' not found.");
            }
        }

        private void EnsureSelectorsLoaded()
        {
            if (_selectors == null || _selectors.Count == 0)
            {
                throw new InvalidOperationException("Selectors have not been loaded. Call InitializeAsync() before using page methods.");
            }
        }
    }
}
