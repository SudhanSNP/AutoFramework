using NUnit.Framework;
using Pages;

namespace Tests.UITests
{
    [TestFixture]
    [Parallelizable]
    public class EPAMHowWeDoItTest : BaseTestFixtures
    {
        EPAMHomePage epamHome = EPAMHomePage.GetInstance;
        EPAMHowWeDoItPage epamHowWeDoIt = EPAMHowWeDoItPage.GetInstance;

        [Test]
        public void EPAMHowWeDoIt()
        {
            List<string> expectedApproach = new List<string> 
            {
                "SCALE UP AND SCALE OUT",
                "CUSTOMER COLLABORATION",
                "HYBRID TEAMS",
                "INDUSTRIALIZED DIGITAL",
                "ENGINEERING SPEED AND QUALITY",
                "OPEN IS THE NEW ADVANTAGE"
            };
            epamHome.ClickEpamHowWeDoIt()
                .GetHeader(out string header);

            Assert.That(header, Is.EqualTo("How We Do It"));

            epamHowWeDoIt.GetApproachHeader(out List<string> approachHeader);

            Assert.AreEqual(approachHeader, expectedApproach);
        }
    }
}
