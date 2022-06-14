using NUnit.Framework;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable]
    public class EPAMHomePageDescriptionTest : BaseTestFixtures
    {
        EPAMHomePage epamHome = EPAMHomePage.GetInstance;

        [Test]
        public void HomePageDescriptionTest()
        {
            List<string> expectedDescription = new List<string> { "CONSULT", "DESIGN", "ENGINEER", "OPERATE", "OPTIMIZE"};
            epamHome.GetDescription(out List<string> actualDescription);

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
