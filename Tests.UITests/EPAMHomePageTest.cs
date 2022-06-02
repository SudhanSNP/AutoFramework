using NUnit.Framework;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class EPAMHomePageTest : BaseTestFixtures
    {
        [Test]
        public void HomePageTest()
        {
            EPAMHomePage epamHome = EPAMHomePage.GetInstance;
            epamHome.AcceptCookies()
                .GetRegionOffice("Americas", out List<string> regions);

            Assert.That(regions.Count == 3);
        }

    }
}
