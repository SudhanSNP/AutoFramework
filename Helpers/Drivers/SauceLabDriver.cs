using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace Helpers.Drivers
{
    public class SauceLabDriver : SauceDriverOptions
    {
        public string BrowserName { get; }
        public string BrowserVersion { get; }
        public string PlatformName { get; }
        public SauceTestContext SauceContext { get; }
        public RemoteWebDriver? Driver { get; set; }

        public SauceLabDriver(string browserName, string browserVersion, string platformName)
        {
            BrowserName = browserName;
            BrowserVersion = browserVersion;
            PlatformName = platformName;
            SauceContext = new SauceTestContext();
        }

        public RemoteWebDriver GetSauceConfig()
        {
            switch(BrowserName)
            {
                case "Chrome":
                    CreateChrome();
                    break;
                case "Firefox":
                    CreateFirefox();
                    break;
                case "Edge":
                    CreateEdge();
                    break;
                default: throw new ArgumentException("Invalid browser");
            }

            return Driver;
        }
        public void CreateEdge()
        {
            Driver = new SauceDriverOptions()
                .EdgeDriver(BrowserVersion, PlatformName);
        }

        public void CreateChrome()
        {
            Driver = new SauceDriverOptions()
                .ChromeDriver(BrowserVersion, PlatformName);
        }

        public void CreateFirefox()
        {
            Driver = new SauceDriverOptions()
                .FirefoxDriver(BrowserVersion, PlatformName);
        }

    }
}
