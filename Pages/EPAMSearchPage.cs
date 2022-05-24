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
            Console.WriteLine("--------------------------- EPAM Search Page ---------------------------");
            _basePage = BasePage.GetInstance;
        }

        public EPAMSearchPage EnterSearchText(string search)
        {
            _basePage.SendText(By.Id("new_form_search"), search);
            return this;
        }

        public EPAMHomePage GoToHome()
        {
            _basePage.ClickElement(By.ClassName("header__logo"));
            return EPAMHomePage.GetInstance;
        }

        public EPAMSearchPage ClickFind()
        {
            _basePage.ClickElement(By.CssSelector(".header-search__submit"));
            return this;
        }

        public EPAMSearchPage GetResultCount(out string result)
        {
            result = _basePage.GetText(By.ClassName("search-results__counter"));
            return this;
        }
    }
}
