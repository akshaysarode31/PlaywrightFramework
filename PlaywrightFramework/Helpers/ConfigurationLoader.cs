using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace PlaywrightFramework.Helpers
{
    public static class ConfigurationLoader
    {
        public static IConfiguration LoadConfiguration(string baseConfigPath = "D:\\Project\\PlaywrightFramework\\PlaywrightFramework\\Configuration\\")
        {
            try
            {
                string plainPassword = "admin123";
                string encryptedPassword2 = EncryptionHelper.Encrypt(plainPassword);
                Console.WriteLine(encryptedPassword2);

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Path.Combine(baseConfigPath, "TestSettings.json"), optional: true, reloadOnChange: true)
                    .AddJsonFile(Path.Combine(baseConfigPath, "appsettings.json"), optional: true, reloadOnChange: true);

                var configuration = builder.Build();

                string encryptedPasswordPath = Path.Combine(baseConfigPath, "encrypted_password.txt");
                if (File.Exists(encryptedPasswordPath))
                {
                    string encryptedPassword = File.ReadAllText(encryptedPasswordPath);
                    string decryptedPassword = EncryptionHelper.Decrypt(encryptedPassword);
                    configuration["Password"] = decryptedPassword;
                }
                else
                {
                    throw new FileNotFoundException("Encrypted password file not found.");
                }

                return configuration;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load configuration.", ex);
            }
        }
    }
}
