using Helpers.Logging;
using Helpers.Reports;
using TechTalk.SpecFlow;

namespace Tests.BDD.Hooks
{
    [Binding]
    public sealed class APITestHook : SpecflowReport
    {

        [BeforeScenario("@APITests")]
        public void BeforeScenarioWithTag()
        {
            Logger.PrintLog(new InfoLogger().LogMessage("API Scenario Started."));
        }

        
        [AfterScenario("@APITests")]
        public void AfterScenario()
        {
            Logger.PrintLog(new InfoLogger().LogMessage("API Scenario Completed."));
        }
    }
}