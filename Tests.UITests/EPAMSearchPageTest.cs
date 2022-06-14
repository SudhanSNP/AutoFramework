using Helpers.Actions;
using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable]
    public class EPAMSearchPageTest : BaseTestFixtures
    {
        [Test]
        public void SearchResultTest()
        {
            EPAMHomePage epamHome = EPAMHomePage.GetInstance;

            epamHome.ClickSearch()
                .WithInSearchPanel()
                .EnterSearchText("Automation")
                .ClickFind()
                .GetResultCount(out string resultCount);

            Assert.That(resultCount, Is.EqualTo("391 RESULTS FOR " + '"' + "AUTOMATION" + '"'));
            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(391));
        }
    }
}
