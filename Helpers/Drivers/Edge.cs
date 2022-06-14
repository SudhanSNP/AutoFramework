using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;

namespace Helpers.Drivers
{
    public sealed class Edge : IDriver
    {
        private IWebDriver driver;

        private static Lazy<Edge> DriverInstance = new Lazy<Edge>(() => new Edge());

        public static Edge GetDriverInstance
        {
            get { return DriverInstance.Value; }
        }

        private Edge()
        {
        }
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
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

        public void SetDriver(RemoteWebDriver driver)
        {
            this.driver = (driver != null) ? driver : new EdgeDriver();
        }
    }
}
