using RestSharp;

namespace RestApiClient.ApiClient
{
    public abstract class RestSharpClient : IRestSharpClient
    {
        
        protected string baseUrl;
        public Dictionary<string, string> queryParam;
        private RestClient Client;
        private RestRequest Request;
        private RestResponse Response;

        public RestClient restClient 
        {
            get { return this.Client; }
            set { this.Client = value; } 
        }
        public RestRequest restRequest
        {
            get { return this.Request; }
            set { this.Request = value; }
        }
        public RestResponse restResponse
        {
            get { return this.Response; }
            set { this.Response = value; }
        }

        public RestSharpClient(string url)
        {
            this.baseUrl = url;
        }

        public void SetRestClient()
        {
            this.Client = new RestClient(baseUrl);
        }

        public void SetRestRequest(RequestType type)
        {
            switch (type)
            {
                case RequestType.Get:
                    Request = new RestRequest(baseUrl, Method.Get);
                    break;
                case RequestType.Post:
                    Request = new RestRequest(baseUrl, Method.Post);
                    break;
                case RequestType.Put:
                    Request = new RestRequest(baseUrl, Method.Put);
                    break;
                case RequestType.Delete:
                    Request = new RestRequest(baseUrl, Method.Delete);
                    break;
                default:
                    throw new ArgumentException("Enter a valid Request type");
            }
        }

        public void SetRestResponse()
        {
            this.Response = new RestResponse();
        }

        public async Task<RestResponse> GetRestResponse()
        {
            return Response;
        }

        public virtual async Task<RestResponse> SendRequest()
        {
            Response = await GetRestResponse();
            return Response;
        }
    }
}
