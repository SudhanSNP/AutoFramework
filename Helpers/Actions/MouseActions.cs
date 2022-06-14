using OpenQA.Selenium;
using Helpers.Logging;

namespace Helpers.Actions
{
    public class MouseActions : DriverActions
    {
        OpenQA.Selenium.Interactions.Actions Action;

        public MouseActions(IWebDriver driver) : base(driver)
        {
        }

        public void ClickElement(By selector)
        {
            WaitUntilElementClickable(selector);
            MoveToElement(selector);
            driver.FindElement(selector).Click();
            Logger.PrintLog(new InfoLogger().LogMessage($"Clicked on the element '{selector}'"));
        }

        protected void MoveToElement(By selector)
        {
            Action = new OpenQA.Selenium.Interactions.Actions(driver);
            Action.MoveToElement(driver.FindElement(selector))
                .Perform();
            Logger.PrintLog(new InfoLogger().LogMessage($"Moved to the element '{selector}'"));
        }

        public void MouseHover(By selector)
        {
            WaitUntilElementDisplayed(selector);
            MoveToElement(selector);
            Logger.PrintLog(new InfoLogger().LogMessage($"Mouse hovered on the element '{selector}'"));
        }

        public void RightClick(By selector)
        {
            Action = new OpenQA.Selenium.Interactions.Actions(driver);
            Action.ContextClick(driver.FindElement(selector))
                .Perform();
            Logger.PrintLog(new InfoLogger().LogMessage($"Right clicked on the element '{selector}'"));
        }
    }
}
