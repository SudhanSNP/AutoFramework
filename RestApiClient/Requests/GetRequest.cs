using RestApiClient.ApiClient;
using RestSharp;

namespace RestApiClient.Requests
{
    public class GetRequest : RestSharpClient
    {
        public GetRequest(string url) : base(url)
        {
            SetRestRequest(RequestType.Get);
        }

        public GetRequest AddRequestHeader()
        {
            restRequest.AddHeader("Accept", "application/json");
            return this;
        }

        public GetRequest AddQueryParameter()
        {
            if (queryParam != null && queryParam.Count >= 1)
            {
                foreach (KeyValuePair<string, string> param in queryParam)
                    restRequest.AddQueryParameter(param.Key, param.Value);
            }
            return this;
        }

        public override async Task<RestResponse> SendRequest()
        {
            restResponse = await GetRestResponse();
            return await restClient.GetAsync(restRequest);
        }
    }
}
