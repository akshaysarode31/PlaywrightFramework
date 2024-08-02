using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Helpers
{
    public class BrowserConfig
    {
        public string BrowserName { get; set; }
        public bool Headless { get; set; }
        public bool Incognito { get; set; }
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }
        public int SlowMo { get; set; }
        public bool TracingEnabled { get; set; }
        public int DefaultTimeout { get; set; }
    }
}
