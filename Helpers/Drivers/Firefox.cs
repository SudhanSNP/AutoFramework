using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Helpers.Drivers
{
    public sealed class Firefox : IDriver
    {
        private IWebDriver driver;

        private static Lazy<Firefox> DriverInstance = new Lazy<Firefox>(()=> new Firefox());

        public static Firefox GetDriverInstance
        {
            get { return Firefox.DriverInstance.Value; }
        }

        public Firefox()
        {
            this.driver = new FirefoxDriver(Directory.GetCurrentDirectory());
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
