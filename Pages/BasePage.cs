using Helpers.Actions;
using OpenQA.Selenium;

namespace Pages
{
    public sealed class BasePage
    {
        public IWebDriver driver;
        public KeyBoardActions keysAction;
        public MouseActions mouseAction;
        public DriverActions driverActions;
        private static Lazy<BasePage> _basePage = new Lazy<BasePage>(() => new BasePage());
        public static BasePage GetInstance
        {
            get
            {
                return _basePage.Value;
            }
        }

        private BasePage()
        {
        }

        public void SetWebDriver(IWebDriver _driver)
        {
            this.driver = _driver;
            driverActions = new DriverActions(driver);
            keysAction = new KeyBoardActions(driver);
            mouseAction = new MouseActions(driver);
        }
    }
}
