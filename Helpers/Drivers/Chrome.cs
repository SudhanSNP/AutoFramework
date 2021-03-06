using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Helpers.Drivers
{
    public sealed class Chrome : IDriver
    {
        private IWebDriver driver;

        private static Lazy<Chrome> DriverInstance = new Lazy<Chrome>(()=> new Chrome());

        public static Chrome GetDriverInstance 
        {
            get { return DriverInstance.Value; }
        }

        private Chrome()
        {
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void SetDriver(RemoteWebDriver driver)
        {
            this.driver = (driver != null) ? driver : new ChromeDriver();
        }

        public void MaximizeDriver()
        {
            driver.Manage().Window.Maximize();
        }

        public void MinimizeDriver()
        {
            driver.Manage().Window.Minimize();
        }

        public void NavigateURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
