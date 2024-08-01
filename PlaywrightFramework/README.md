# PlaywrightFramework

A test automation framework built with Playwright and .NET, designed to automate web applications. This framework follows the SOLID principles to ensure scalability and maintainability.

## Features

- Browser automation with Playwright
- Supports multiple browser types (Chromium, Firefox, Webkit)
- Environment-specific configurations
- Encrypted password handling
- Tracing and recording functionality
- Parallel test execution

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Playwright CLI](https://playwright.dev/docs/test-cli)

### Installation
1. Clone the repository:
	```bash
   git clone https://github.com/akshaysarode31/PlaywrightFramework.git
   cd PlaywrightFramework
	```
2. Install Playwright:
	```bash
   npx playwright install
	```
3. Restore .NET dependencies:
	```bash
    dotnet restore
	```
	
### Configuration
The framework uses appsettings.json for configuration. Environment-specific settings can be placed in appsettings.{Environment}.json files.

Example *appsettings.json*:
```json
{
  "Environment": "QA",
  "QA": {
    "Browser": {
      "Name": "chromium",
      "Headless": false,
      "Incognito": false,
      "ViewportWidth": 1280,
      "ViewportHeight": 720,
      "SlowMo": 0,
      "Tracing": true
    },
    "User": {
      "Username": "admin",
      "Password": "admin123"
    },
    "AppSettings": {
      "BaseUrl": "https://opensource-demo.orangehrmlive.com/"
    }
  }
}
```

### Encrypted Password
To encrypt a password, use the EncryptionHelper and save the encrypted password to encrypted_password.txt:
```string plainPassword = "admin123";
string encryptedPassword = EncryptionHelper.Encrypt(plainPassword);
File.WriteAllText("Configuration/encrypted_password.txt", encryptedPassword);
```
### Running Tests
1. Build the project:
	```bash
   dotnet Build
	```
2. Run the tests:
	```bash
   dotnet test
	```
### Project Structure
* **Configuration/: Configuration files**
* **Helpers/: Helper classes and utilities**
* **Interface/: Interface definitions**
* **Pages/: Page object models**
* **Tests/: Test classes**
 
## Contributions
* **Akshay Sarode** - [LinkedIn Profile](www.linkedin.com/in/akshaysarode31)
## Contributing
Contributions are welcome! Please open an issue or submit a pull request.
## License
