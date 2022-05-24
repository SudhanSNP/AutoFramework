using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Helpers.Drivers
{
    public class Firefox : IDriver
    {
        private IWebDriver driver;

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
