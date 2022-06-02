using RestSharp;
using RestApiClient.ApiClient;
using System.Net;

namespace RestApiClient.Requests
{
    public class PostRequest : RestSharpClient
    {
        protected void SetRequest()
        {
            SetRestRequest(RequestType.Post);
        }
        protected void AddRequestHeader()
        {
            restRequest.AddHeader("Content-Type", "application/json");
        }
        protected void AddRequestBody<T>(T modal)
        {
            restRequest.AddBody(modal);
        }
        protected override async Task<RestResponse> SendRequest()
        {
            restResponse = await restClient.PostAsync(restRequest);
            return restResponse;
        }

        protected HttpStatusCode GetStatusCode()
        {
            return restResponse.StatusCode;
        }
    }
}
