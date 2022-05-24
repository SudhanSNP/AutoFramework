using Helpers.Actions;
using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    public class EPAMSearchPageTest
    {
        private IWebDriver driver;
        private IDriver WebDriver;

        [SetUp]
        public void SetUp()
        {
            WebDriver = new DriverFactory(DriverType.Firefox)
                .GetDriverType();

            driver = WebDriver.GetDriver();
            WebDriver.MaximizeDriver();
            WebDriver.NavigateURL("https://www.epam.com/");
            BasePage.GetInstance.SetWebDriver(driver);
        }

        [Test]
        public void SearchResultTest()
        {
            EPAMHomePage epamHome = EPAMHomePage.GetInstance;

            epamHome.ClickSearch()
                .WithInSearchPanel()
                .EnterSearchText("Automation")
                .ClickFind()
                .GetResultCount(out string resultCount);

            Assert.That(resultCount, Is.EqualTo("385 RESULTS FOR " + '"' + "AUTOMATION" + '"'));
            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(385));
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }
    }
}
