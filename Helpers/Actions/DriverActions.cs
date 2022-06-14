using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Helpers.Logging;

namespace Helpers.Actions
{
    public class DriverActions
    {
        public IWebDriver driver { get; set; }

        public DriverActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetText(By selector)
        {
            return WaitUntilElementDisplayed(selector).Text;
        }

        public string GetAttributes(By selector, string attribute)
        {
            return WaitUntilElementDisplayed(selector).GetAttribute(attribute);
        }

        public virtual bool GetPresenceOfElement(By selector)
        {
            bool result = driver.FindElement(selector).Displayed;
            Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' is present"));
            return result;
        }

        public void GetText(By selector, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.Text).ToList();
        }

        public void GetAttributes(By selector, string attribute, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.GetAttribute(attribute)).ToList();
        }

        protected virtual IWebElement WaitUntilElementDisplayed(By selector)
        {
            IWebElement element = new WebDriverWait(driver, new TimeSpan(0, 0, 15))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' displayed"));
            return element;
        }

        protected virtual IWebElement WaitUntilElementClickable(By selector)
        {
            IWebElement element = new WebDriverWait(driver, new TimeSpan(0, 0, 5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            Logger.PrintLog(new InfoLogger().LogMessage($"Element '{selector}' displayed"));
            return element;
        }
    }
}
