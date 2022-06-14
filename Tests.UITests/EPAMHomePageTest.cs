using NUnit.Framework;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable]
    public class EPAMHomePageTest : BaseTestFixtures
    {
        [Test]
        public void HomePageTest()
        {
            EPAMHomePage epamHome = EPAMHomePage.GetInstance;
            epamHome.AcceptCookies()
                .GetRegionOffice("Americas", out List<string> americasRegions)
                .ClickRegion("EMEA")
                .GetRegionOffice("EMEA", out List<string> emeaRegions)
                .ClickRegion("APAC")
                .GetRegionOffice("APAC", out List<string> apacRegions);

            Assert.That(americasRegions.Count == 4);
            Assert.That(emeaRegions.Count == 8);
            Assert.That(apacRegions.Count == 8);
        }

    }
}
