using NUnit.Framework;
using RestApiClient.Modal.Users;
using RestApiClient.Users;

namespace Tests.BDD.StepDefinitions.APITests
{
    [Binding]
    public class GetUsersListStepDefinitions
    {
        private GetUsersRequest GetUsers;
        private UsersData Users;

        [Given(@"The API clients are Initialized")]
        public void GivenTheAPIClientsAreInitialized()
        {
            GetUsers = new GetUsersRequest()
                .BuildRequest();
        }

        [When(@"The User names are retrieved from the Get API Request")]
        public async Task WhenTheUserNamesAreRetrievedFromTheGetAPIRequest()
        {
            Users = await GetUsers.GetUsersDataList();
        }

        [Then(@"The following Names should present")]
        public void ThenTheFollowingNamesShouldPresent(Table table)
        {
            List<string> expectedNames = table.Rows.Select(t => t["Name"]).ToList();
            List<string> actualNames = Users.Data.Select(usr => usr.FirstName).ToList();

            Assert.AreEqual(expectedNames, actualNames);
        }

    }
}
