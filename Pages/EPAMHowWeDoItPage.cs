using OpenQA.Selenium;

namespace Pages
{
    public sealed class EPAMHowWeDoItPage
    {
        private static Lazy<EPAMHowWeDoItPage> _epamHowWeDoIt = new Lazy<EPAMHowWeDoItPage>(() => new EPAMHowWeDoItPage());
        private static BasePage _basePage;
        public static EPAMHowWeDoItPage GetInstance
        {
            get
            {
                return _epamHowWeDoIt.Value;
            }
        }

        private EPAMHowWeDoItPage()
        {
            _basePage = BasePage.GetInstance;
        }

        #region Locators
        private static readonly By Header = By.XPath("//h1");
        private static readonly By ApproachHeader = By.CssSelector(".color-light-blue");
        #endregion

        #region Actions
        public EPAMHowWeDoItPage GetHeader(out string header)
        {
            header = _basePage.driverActions.GetText(Header);
            return this;
        }

        public EPAMHowWeDoItPage GetApproachHeader(out List<string> header)
        {
            _basePage.driverActions.GetText(ApproachHeader, out header);
            return this;
        }
        #endregion
    }
}
