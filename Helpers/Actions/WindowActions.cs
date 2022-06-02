using OpenQA.Selenium;

namespace Helpers.Actions
{
    public class WindowActions : DriverActions
    {
        public string CurrentWindow()
        {
            return driver.CurrentWindowHandle;
        }

        public void SwitchWindow()
        {
            foreach (var window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
        }

        public void SwitchWindowByName(string window)
        {
            driver.SwitchTo().Window(window);
        }
    }
}
