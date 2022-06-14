using Helpers.Actions;
using OpenQA.Selenium;

namespace Pages
{
    public sealed class EPAMSearchPage
    {
        private static Lazy<EPAMSearchPage> _epamSearch = new Lazy<EPAMSearchPage>(() => new EPAMSearchPage());
        private static BasePage _basePage;
        public static EPAMSearchPage GetInstance
        {
            get
            {
                return _epamSearch.Value;
            }
        }

        private EPAMSearchPage()
        {
            _basePage = BasePage.GetInstance;
        }

        #region Locators
        private static readonly By SearchText = By.Id("new_form_search");
        private static readonly By MainLogo = By.ClassName("header__logo");
        private static readonly By FindButton = By.CssSelector(".header-search__submit");
        private static readonly By ResultText = By.ClassName("search-results__counter");
        #endregion

        #region Actions
        public EPAMSearchPage EnterSearchText(string search)
        {
            _basePage.keysAction.SendText(SearchText, search);
            return this;
        }

        public EPAMHomePage GoToHome()
        {
            _basePage.mouseAction.ClickElement(MainLogo);
            return EPAMHomePage.GetInstance;
        }

        public EPAMSearchPage ClickFind()
        {
            _basePage.mouseAction.ClickElement(FindButton);
            return this;
        }

        public EPAMSearchPage GetResultCount(out string result)
        {
            result = _basePage.driverActions.GetText(ResultText);
            return this;
        }
        #endregion
    }
}
