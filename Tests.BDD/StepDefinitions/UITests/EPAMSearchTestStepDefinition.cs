using OpenQA.Selenium;
using Pages;
using NUnit.Framework;
using Tests.BDD.Drivers;

namespace Tests.BDD.StepDefinitions.UITests
{
    [Binding]
    public class EPAMSearchTestStepDefinition
    {
        private EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        private EPAMSearchPage epamSearch = EPAMSearchPage.GetInstance;
        private DriverHelper driverHelper = DriverHelper.GetInstance;

        [Given(@"I have entered the EPAM home page")]
        public void GivenIHaveEnteredTheEPAMHomePage()
        {
            driverHelper.WebDriver.NavigateURL("https://www.epam.com/");
        }

        [Given(@"I have navigated to the Search panel")]
        public void GivenIHaveNavigatedToTheSearchPanel()
        {
            epamHome.AcceptCookies()
                .ClickSearch();
        }

        [When(@"I entered the SkillSet to search as (.*)")]
        public void WhenIEnteredTheSkillSetToSearchAsAutomation(string skill)
        {

            epamSearch.EnterSearchText(skill)
                .ClickFind();
        }

        [Then(@"The record message of the search result should match the (.*) and (.*)")]
        public void ThenTheRecordMessageOfTheSearchResultShouldMatchThe(string skill, int count)
        {
            epamSearch.GetResultCount(out string resultCount);

            Assert.That(resultCount, Is.EqualTo($"{count} RESULTS FOR " + '"' + skill + '"'));
            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(count));
        }

        [Given(@"I have entered the EPAM home page (.*)")]
        public void GivenIHaveEnteredTheEPAMHomePageSkill(string skill)
        {
            throw new PendingStepException();
        }

        [Given(@"I have navigated to the Search panel (.*)")]
        public void GivenIHaveNavigatedToTheSearchPanelRecord(int record)
        {
            throw new PendingStepException();
        }

    }
}
