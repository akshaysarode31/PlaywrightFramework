using Microsoft.Extensions.Configuration;

namespace PlaywrightFramework.Helpers
{
    public static class ConfigurationLoader
    {
        public static BrowserConfig LoadBrowserConfig(IConfiguration configuration)
        {
            return new BrowserConfig
            {
                BrowserName = configuration["Browser:Name"] ?? throw new ArgumentNullException("Browser:Name is missing"),
                Headless = bool.TryParse(configuration["Browser:Headless"], out var headlessValue) ? headlessValue : true,
                Incognito = bool.TryParse(configuration["Browser:Incognito"], out var incognitoValue) ? incognitoValue : false,
                ViewportWidth = int.TryParse(configuration["Browser:ViewportWidth"], out var viewportWidthValue) ? viewportWidthValue : 1920,
                ViewportHeight = int.TryParse(configuration["Browser:ViewportHeight"], out var viewportHeightValue) ? viewportHeightValue : 1080,
                SlowMo = int.TryParse(configuration["Browser:SlowMo"], out var slowMoValue) ? slowMoValue : 0,
                TracingEnabled = bool.TryParse(configuration["Browser:Tracing"], out var tracingEnabledValue) ? tracingEnabledValue : false,
                DefaultTimeout = int.TryParse(configuration["Browser:DefaultTimeout"], out var defaultTimeoutValue) ? defaultTimeoutValue : 30000
            };
        }

        public static IConfiguration LoadConfiguration(string baseConfigPath = "D:\\Project\\PlaywrightFramework\\PlaywrightFramework\\Configuration\\")
        {
            try
            {
                /*string plainPassword = "admin123";
                string encryptedPassword2 = EncryptionHelper.Encrypt(plainPassword);
                Console.WriteLine("This is encrypted password "+encryptedPassword2);*/

                var builder = new ConfigurationBuilder()
                    .SetBasePath(baseConfigPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var configuration = builder.Build();
                var environment = configuration["Environment"];

                // Load environment-specific configuration
                if (!string.IsNullOrEmpty(environment))
                {
                    builder.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
                }

                // Rebuild configuration to include environment-specific settings
                configuration = builder.Build();

                // Decrypt password if encrypted password file exists
                string encryptedPasswordPath = Path.Combine(baseConfigPath, "encrypted_password.txt");
                if (File.Exists(encryptedPasswordPath))
                {
                    string encryptedPassword = File.ReadAllText(encryptedPasswordPath);
                    string decryptedPassword = EncryptionHelper.Decrypt(encryptedPassword);
                    configuration[$"{environment}:User:Password"] = decryptedPassword;
                }
                else
                {
                    throw new FileNotFoundException("Encrypted password file not found.");
                }

                return configuration.GetSection(environment);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load configuration.", ex);
            }
        }
    }
}
