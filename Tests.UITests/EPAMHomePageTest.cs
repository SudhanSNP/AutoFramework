using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    public class EPAMHomePageTest
    {
        private IWebDriver driver;
        private IDriver WebDriver;

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

        [Test]
        public void HomePageTest()
        {
            EPAMHomePage epamHome = EPAMHomePage.GetInstance;
            epamHome.AcceptCookies()
                .GetRegionOffice("Americas", out List<string> regions);

            Assert.That(regions.Count == 3);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }
    }
}
