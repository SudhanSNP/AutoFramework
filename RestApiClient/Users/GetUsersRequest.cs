using RestApiClient.Requests;
using RestApiClient.Modal.Users;
using Helpers.Json;

namespace RestApiClient.Users
{
    public class GetUsersRequest : GetRequest
    {
        public GetUsersRequest(Dictionary<string, string> queryParam = null)
        {
            this.baseUrl = "https://reqres.in/api/users";
            this.queryParam = queryParam;
        }

        public GetUsersRequest BuildRequest()
        {
            SetRestClient();
            SetRequest();
            AddRequestHeader();
            AddQueryParameter();
            return this;
        }

        public async Task<UsersData> GetUsersDataList()
        {
            var response = await SendRequest();
            return await JsonHelper.JsonDeserializeAsync<UsersData>(response.Content);
        }
    }
}
