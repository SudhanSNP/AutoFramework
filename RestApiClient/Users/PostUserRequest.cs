using Helpers.Json;
using RestApiClient.Requests;
using RestApiClient.Modal.Users;
using System.Net;

namespace RestApiClient.Users
{
    public class PostUserRequest : PostRequest
    {
        public HttpStatusCode ResponseCode { get; private set; }
        public PostUserRequest()
        {
            this.baseUrl = "https://reqres.in/api/users";
            this.queryParam = queryParam;
        }
        public PostUserRequest BuildRequest(CreateUser body)
        {
            SetRestClient();
            SetRequest();
            AddRequestHeader();
            AddRequestBody(body);
            return this;
        }
        public async Task<CreateUser> PostUsersDataList()
        {
            var response = await SendRequest();
            ResponseCode = response.StatusCode;
            return await JsonHelper.JsonDeserializeAsync<CreateUser>(response.Content);
        }
    }
}
