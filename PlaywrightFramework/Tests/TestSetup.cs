﻿using Microsoft.Extensions.Configuration;
using PlaywrightFramework.Helpers;
using PlaywrightFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        public static IConfiguration Configuration { get; private set; }
        public static BrowserConfig BrowserConfig { get; private set; }
        private IBrowserWrapper _browserWrapper;


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Configuration = ConfigurationLoader.LoadConfiguration();
            BrowserConfig = ConfigurationLoader.LoadBrowserConfig(Configuration);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            // Ensure all browser instances are closed
            if (_browserWrapper != null)
            {
                await _browserWrapper.DisposeAsync();
            }
        }
    }
}