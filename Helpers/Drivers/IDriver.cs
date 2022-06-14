using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Helpers.Drivers
{
    public interface IDriver
    {
        public IWebDriver GetDriver();
        public void SetDriver(RemoteWebDriver driver);
        public void MaximizeDriver();
        public void MinimizeDriver();
        public void NavigateURL(string url);
        public void CloseDriver();
    }
}
