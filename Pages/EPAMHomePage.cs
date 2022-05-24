using Helpers.Actions;
using OpenQA.Selenium;

namespace Pages
{
    public sealed class EPAMHomePage
    {
        private static Lazy<EPAMHomePage> _epamHome = new Lazy<EPAMHomePage>(() => new EPAMHomePage());
        private static BasePage _basePage;
        public static EPAMHomePage GetInstance
        {
            get
            {
                return _epamHome.Value;
            }
        }

        private EPAMHomePage()
        {
            Console.WriteLine("--------------------------- EPAM Home Page ---------------------------");
            _basePage = BasePage.GetInstance;
        }

        public EPAMSearchPage WithInSearchPanel() => EPAMSearchPage.GetInstance;

        public EPAMHomePage ClickSearch()
        {
            _basePage.ClickElement(By.XPath("//button[contains(@class, 'header-search__button')]"));
            return this;
        }
        public EPAMHomePage AcceptCookies()
        {
            _basePage.ClickElement(By.XPath("//button[text()='Accept All']"));
            return this;
        }

        public EPAMHomePage GetPresenceOfSearch(out bool isPresent)
        {
            isPresent = _basePage.GetPresenceOfElement(By.XPath("//button[contains(@class, 'header-search__button')]"));
            return this;
        }

        public EPAMHomePage ClickLanguage()
        {
            _basePage.ClickElement(By.XPath("//button[contains(@class, 'location-selector__button')]"));
            return this;
        }

        public EPAMHomePage ClickRegion(string Region)
        {
            _basePage.ClickElement(By.XPath($"//a[text()='{Region}']"));
            return this;
        }

        public EPAMHomePage GetRegionOffice(string Region, out List<string> offices)
        {
            _basePage.GetAttributes(By.XPath($"//a[text()='{Region}']/following::div[@class='owl-item active']/div"), "data-country", out offices);
            return this;
        }
    }
}
