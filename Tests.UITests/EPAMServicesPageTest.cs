using NUnit.Framework;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable]
    public class EPAMServicesPageTest : BaseTestFixtures
    {
        EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        EPAMServicesPage epamServices = EPAMServicesPage.GetInstance;

        [Test]
        public void HomePageDescriptionTest()
        {
            List<string> expectedDescription = new List<string> { "CONSULT", "DESIGN", "ENGINEER", "OPERATE", "OPTIMIZE" };
            epamHome.ClickEpamServices()
                .GetDescription(out List<string> actualDescription);

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
