using Helpers.Drivers;
using OpenQA.Selenium;

namespace Tests.BDD.Drivers
{
    public sealed class DriverHelper
    {
        public IWebDriver driver { get; set; } 
        public IDriver WebDriver { get; set; }
        private static Lazy<DriverHelper> Instance = new Lazy<DriverHelper>(()=> new DriverHelper());

        public static DriverHelper GetInstance 
        { 
            get 
            {
                return Instance.Value;
            } 
        }

        private DriverHelper()
        { }
    }
}
