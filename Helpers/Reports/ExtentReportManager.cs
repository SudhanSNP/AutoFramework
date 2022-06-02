using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace Helpers.Reports
{
    public class ExtentReportManager
    {
        private static string ReportPath;
        private static ExtentHtmlReporter ReportHelper;
        private static ExtentReports ExtentReport = new ExtentReports();
        private ExtentTest Test;

        public string GetReportPath()
        {
            return ReportPath;
        }

        private static void SetReportPath(string path)
        {
            ReportPath = path;
        }

        private static void SetReportHelper()
        {
            ReportHelper = new ExtentHtmlReporter(ReportPath);
        }

        public ExtentHtmlReporter GetReportHelper()
        {
            return ReportHelper;
        }

        private static void AttachReport()
        {
            ExtentReport.AttachReporter(ReportHelper);
        }

        public static ExtentReports ExtendReportProvider()
        {
            SetReportPath($"{TestContext.CurrentContext.TestDirectory}\\Reports\\{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd_MM_yyyy_HHmmss")}.html");
            SetReportHelper();
            AttachReport();

            return ExtentReport;
        }
    }
}
