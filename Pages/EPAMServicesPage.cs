using OpenQA.Selenium;

namespace Pages
{
    public sealed class EPAMServicesPage
    {
        private static Lazy<EPAMServicesPage> _epamService = new Lazy<EPAMServicesPage>(() => new EPAMServicesPage());
        private static BasePage _basePage;
        public static EPAMServicesPage GetInstance
        {
            get
            {
                return _epamService.Value;
            }
        }

        private EPAMServicesPage()
        {
            _basePage = BasePage.GetInstance;
        }

        #region Locators
        private static readonly By Header = By.CssSelector(".title--mixed-case");
        private static readonly By Description = By.XPath("//div[@class='rollover-tiles__description']/strong");
        #endregion

        #region Actions
        public EPAMServicesPage GetHeader(out string header)
        {
            header = _basePage.driverActions.GetText(Header);
            return this;
        }

        public EPAMServicesPage GetDescription(out List<string> descriptions)
        {
            _basePage.driverActions.GetText(Description, out descriptions);
            return this;
        }

        public EPAMServicesPage DescriptionHover(string description)
        {
            _basePage.mouseAction.MouseHover(By.XPath($"//div[@class='rollover-tiles__description']/strong[text()='{description}']"));
            return this;
        }

        public EPAMServicesPage GetDescriptionText(string description, out string descriptionText)
        {
            descriptionText = _basePage.driverActions.GetText(By.XPath($"//div[@class='rollover-tiles__description']/strong[text()='{description}']/following-sibling::p"));
            return this;
        }
        #endregion
    }
}
