using Helpers.Drivers;
using Helpers.Reports;
using Pages;
using Tests.BDD.Drivers;

namespace Tests.BDD.Hooks
{
    [Binding]
    public sealed class UITestHook : NUnitReport
    {
        private DriverHelper driverHelper = DriverHelper.GetInstance;

        [BeforeScenario("@UITests")]
        public void BeforeScenarioWithTag()
        {
            driverHelper.WebDriver = new DriverFactory(DriverType.Chrome)
                .GetDriverType();

            driverHelper.driver = driverHelper.WebDriver.GetDriver();
            driverHelper.WebDriver.MaximizeDriver();
            BasePage.GetInstance
                .SetWebDriver(driverHelper.driver);
        }

        [AfterScenario("@UITests")]
        public void AfterScenario()
        {
            driverHelper.WebDriver.CloseDriver();
        }
    }
}