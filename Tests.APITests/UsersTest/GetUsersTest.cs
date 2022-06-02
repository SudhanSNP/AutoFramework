using NUnit.Framework;
using RestApiClient.Modal.Users;
using RestApiClient.Users;

namespace Tests.APITests.UsersTest
{
    [TestFixture]
    public class GetUsersTest
    {
        [Test]
        public async Task GetUsers()
        {
            List<string> expectedNames = new List<string> { "George", "Janet", "Emma", "Eve", "Charles", "Tracey" };

            UsersData Users = await new GetUsersRequest()
                .BuildRequest()
                .GetUsersDataList();

            List<string> actualNames = Users.Data.Select(usr => usr.FirstName).ToList();

            Assert.AreEqual(expectedNames, actualNames);

            expectedNames = new List<string> { "Michael", "Lindsay", "Tobias", "Byron", "George", "Rachel" };

            Users = await new GetUsersRequest(new Dictionary<string, string> { { "page", "2" } })
                .BuildRequest()
                .GetUsersDataList();

            actualNames = Users.Data.Select(usr => usr.FirstName).ToList();

            Assert.AreEqual(expectedNames, actualNames);
        }
    }
}