using RestSharp;

namespace RestApiClient.ApiClient
{
    public abstract class RestSharpClient : IRestSharpClient
    {
        
        protected string baseUrl { get; set; }
        public Dictionary<string, string> queryParam { get; set; } 

        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
        public RestResponse restResponse { get; set; }

        public void SetRestClient()
        {
            restClient = new RestClient(baseUrl);
        }

        public void SetRestRequest(RequestType type)
        {
            switch (type)
            {
                case RequestType.Get:
                    restRequest = new RestRequest(baseUrl, Method.Get);
                    break;
                case RequestType.Post:
                    restRequest = new RestRequest(baseUrl, Method.Post);
                    break;
                case RequestType.Put:
                    restRequest = new RestRequest(baseUrl, Method.Put);
                    break;
                case RequestType.Delete:
                    restRequest = new RestRequest(baseUrl, Method.Delete);
                    break;
                default:
                    throw new ArgumentException("Enter a valid Request type");
            }
        }

        public void SetRestResponse()
        {
            this.restResponse = new RestResponse();
        }

        protected virtual async Task<RestResponse> SendRequest()
        {
            restResponse = new RestResponse();
            return restResponse;
        }
    }
}
