using OpenQA.Selenium;
using Pages;
using Helpers.Drivers;
using NUnit.Framework;
using Helpers.Reports;

namespace Tests.UITests
{
    public class BaseTestFixtures : NUnitReport
    {
        protected IWebDriver driver;
        protected IDriver WebDriver;

        [SetUp]
        public void SetUp()
        {
            WebDriver = new DriverFactory(DriverType.Chrome)
                .GetDriverType();

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
