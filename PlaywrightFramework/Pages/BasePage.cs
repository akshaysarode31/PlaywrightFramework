using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;


namespace PlaywrightFramework.Pages
{
    public abstract class BasePage
    {
        protected readonly IDictionary<string, IDictionary<string, Selector>> _selectors;
        protected readonly IBrowserWrapper BrowserWrapper;
        protected readonly IConfiguration Configuration;

        protected BasePage(IBrowserWrapper browserWrapper, IConfiguration configuration)
        {
            BrowserWrapper = browserWrapper;
            Configuration = configuration;
        }

        public async Task InitializeAsync(params string[] pageNames)
        {
            foreach (var pageName in pageNames)
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

        public async Task NavigateToAsync(string url)
        {
            await BrowserWrapper.NavigateToAsync(url);
        }

        protected async Task FillAsync(string locatorSet, string selectorName, string value)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            await BrowserWrapper.FillAsync(selector, value);
        }

        protected async Task ClickAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            await BrowserWrapper.ClickAsync(selector);
        }

        protected async Task<bool> IsVisibleAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            return await BrowserWrapper.IsVisibleAsync(selector);
        }

        protected async Task<string> GetTextContentAsync(string locatorSet, string selectorName)
        {
            EnsureSelectorsLoaded();
            var selector = GetSelector(locatorSet, selectorName);
            return await BrowserWrapper.GetTextContentAsync(selector);
        }

        private Selector GetSelector(string locatorSet, string selectorName)
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
