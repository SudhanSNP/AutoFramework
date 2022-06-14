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

        #region Locators
        private static readonly By SearchButton = By.XPath("//button[contains(@class, 'header-search__button')]");
        private static readonly By AcceptAllButton = By.XPath("//button[text()='Accept All']");
        private static readonly By Description = By.XPath("//div[@class='rollover-tiles__description']/strong");
        private static readonly By ServicesMenu = By.XPath("//a[text()='Services']");
        private static readonly By HowWeDoItMenu = By.XPath("//a[text()='How We Do It']");
        #endregion

        #region Actions
        private EPAMHomePage()
        {
            _basePage = BasePage.GetInstance;
        }

        public EPAMSearchPage WithInSearchPanel() => EPAMSearchPage.GetInstance;

        public EPAMHomePage ClickSearch()
        {
            _basePage.mouseAction.ClickElement(SearchButton);
            return this;
        }
        public EPAMHomePage AcceptCookies()
        {
            _basePage.mouseAction.ClickElement(AcceptAllButton);
            return this;
        }

        public EPAMHomePage GetPresenceOfSearch(out bool isPresent)
        {
            isPresent = _basePage.driverActions.GetPresenceOfElement(SearchButton);
            return this;
        }

        public EPAMHomePage ClickLanguage()
        {
            _basePage.mouseAction.ClickElement(By.XPath("//button[contains(@class, 'location-selector__button')]"));
            return this;
        }

        public EPAMHomePage ClickRegion(string Region)
        {
            _basePage.mouseAction.ClickElement(By.XPath($"//a[text()='{Region}']"));
            return this;
        }

        public EPAMHomePage GetRegionOffice(string Region, out List<string> offices)
        {
            _basePage.driverActions.GetAttributes(By.XPath($"//a[text()='{Region}']/following::div[@class='owl-item active']/div"), "data-country", out offices);
            return this;
        }

        public EPAMHomePage GetDescription(out List<string> descriptions)
        {
            _basePage.driverActions.GetText(Description, out descriptions);
            return this;
        }

        public EPAMServicesPage ClickEpamServices()
        {
            _basePage.mouseAction.ClickElement(ServicesMenu);
            return EPAMServicesPage.GetInstance;
        }

        public EPAMHowWeDoItPage ClickEpamHowWeDoIt()
        {
            _basePage.mouseAction.ClickElement(HowWeDoItMenu);
            return EPAMHowWeDoItPage.GetInstance;
        }
        #endregion
    }
}
