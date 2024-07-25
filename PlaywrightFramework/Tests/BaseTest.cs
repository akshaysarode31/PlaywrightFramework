using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Tests
{
    public class BaseTest
    {
        protected IConfiguration Configuration { get; private set; }
        protected BrowserWrapper BrowserWrapper { get; private set; }

        [SetUp]
        public async Task SetUp()
        {
            // Load configuration
            Configuration = ConfigurationLoader.LoadConfiguration();

            // Initialize the browser and page
            var page = await BrowserHelper.GetNewPageAsync(Configuration);
            BrowserWrapper = new BrowserWrapper(page);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Clean up resources
            await BrowserWrapper.Page.CloseAsync();
        }
    }
}
