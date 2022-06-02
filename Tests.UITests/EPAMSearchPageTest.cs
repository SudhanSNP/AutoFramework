using Helpers.Actions;
using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class EPAMSearchPageTest : BaseTestFixtures
    {
        private IWebDriver driver;
        private IDriver WebDriver;

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
    }
}
