using NUnit.Framework;
using RestApiClient.Modal.Users;
using RestApiClient.Users;
using System.Net;

namespace Tests.APITests.UsersTest
{
    [TestFixture]
    public class CreateUsersTest
    {
        [Test]
        public async Task CreateUsers()
        {
            CreateUser User = new CreateUser { Name = "Sudhan", Job = "QA Automation" };

            var request = new PostUserRequest()
                .BuildRequest(User);

            User = await request.PostUsersDataList();

            Assert.AreEqual(request.ResponseCode, HttpStatusCode.Created);
            Assert.AreEqual(User.Name, "Sudhan");
            Assert.AreEqual(User.Job, "QA Automation");
        }
    }
}
