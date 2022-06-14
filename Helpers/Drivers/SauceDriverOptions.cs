using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Helpers.Drivers
{
    public class SauceDriverOptions
    {
        private SauceTestContext SauceContext => new SauceTestContext();

        public RemoteWebDriver EdgeDriver(string browserVersion, string platformName)
        {
            var options = new EdgeOptions()
            {
                BrowserVersion = browserVersion,
                PlatformName = platformName
            };
            options.AddAdditionalOption("sauce:options", SauceContext.SauceOptions());
            Uri uri = new Uri("https://sudhan_s:11d082dd-d931-4291-9a46-6e506ed1d01d@ondemand.apac-southeast-1.saucelabs.com:443/wd/hub");
            return new RemoteWebDriver(uri, options.ToCapabilities(), TimeSpan.FromSeconds(60));
        }

        public RemoteWebDriver ChromeDriver(string browserVersion, string platformName)
        {
            var options = new ChromeOptions()
            {
                BrowserVersion = browserVersion,
                PlatformName = platformName
            };
            options.AddAdditionalOption("sauce:options", SauceContext.SauceOptions());
            Uri uri = new Uri("https://sudhan_s:11d082dd-d931-4291-9a46-6e506ed1d01d@ondemand.apac-southeast-1.saucelabs.com:443/wd/hub");
            return new RemoteWebDriver(uri, options.ToCapabilities(), TimeSpan.FromSeconds(60));
        }

        public RemoteWebDriver FirefoxDriver(string browserVersion, string platformName)
        {
            var options = new FirefoxOptions()
            {
                BrowserVersion = browserVersion,
                PlatformName = platformName
            };
            options.AddAdditionalOption("sauce:options", SauceContext.SauceOptions());
            Uri uri = new Uri("https://sudhan_s:11d082dd-d931-4291-9a46-6e506ed1d01d@ondemand.apac-southeast-1.saucelabs.com:443/wd/hub");
            return new RemoteWebDriver(uri, options.ToCapabilities(), TimeSpan.FromSeconds(60));
        }
    }
}
