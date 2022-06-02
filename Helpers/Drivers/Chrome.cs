using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Helpers.Drivers
{
    public sealed class Chrome : IDriver
    {
        private IWebDriver driver;

        private static Lazy<Chrome> DriverInstance = new Lazy<Chrome>(()=> new Chrome());

        public static Chrome GetDriverInstance 
        {
            get { return Chrome.DriverInstance.Value; }
        }

        private Chrome()
        {
            this.driver = new ChromeDriver();
        }

        public IWebDriver GetDriver()
        {
            return driver;
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
