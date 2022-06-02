using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Helpers.Reports
{
    public class NUnitReport
    {
        private ExtentReports Report;
        private ExtentTest Test;

        [OneTimeSetUp]
        public void ReportSetUp()
        {
            Report = ExtentReportManager.ExtendReportProvider($"{Directory.GetCurrentDirectory()}\\Reports\\{TestContext.CurrentContext.Test.Name}");
        }

        [SetUp]
        public void TestReport()
        {
            Test = Report.CreateTest(TestContext.CurrentContext.Test.Name);
            Test.Log(Status.Info, "Starting the Reporting");
        }

        [TearDown]
        public void ReportTearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                Test.Fail(TestContext.CurrentContext.Result.Message);
            else if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                Test.Pass("Test Passed!");
            else
                Test.Skip("Test Case Skipped!");
            Report.Flush();
        }
    }
}
