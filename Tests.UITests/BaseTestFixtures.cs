using OpenQA.Selenium;
using Pages;
using Helpers.Drivers;
using NUnit.Framework;
using Helpers.Reports;
using OpenQA.Selenium.Remote;
using System.Configuration;
using Helpers.Configuration;
using System.Reflection;

namespace Tests.UITests
{
    public class BaseTestFixtures : NUnitReport
    {
        protected IWebDriver driver;
        protected IDriver WebDriver;
        protected RemoteWebDriver RemoteDriver;

        [OneTimeSetUp]
        public void BrowserSetUp()
        {
            ConfigurationSetting.AssemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            Enum.TryParse(ConfigurationSetting.Get("Browser"), out DriverType browser);
            WebDriver = new DriverFactory(browser)
                .GetDriverType();
            var isSauceTest = Convert.ToBoolean(ConfigurationSetting.Get("SauceTest"));
            RemoteDriver = (isSauceTest == true) ? new SauceLabDriver(browser.ToString(), "latest", "Windows").GetSauceConfig() : null;
        }
        

        [SetUp]
        public void SetUp()
        {
            WebDriver.SetDriver(RemoteDriver);
            driver = WebDriver.GetDriver();
            WebDriver.MaximizeDriver();
            WebDriver.NavigateURL("https://www.epam.com/");
            BasePage.GetInstance.SetWebDriver(driver);
        }


        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }

    }
}
