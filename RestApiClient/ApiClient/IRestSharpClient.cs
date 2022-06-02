using RestSharp;

namespace RestApiClient.ApiClient
{
    public interface IRestSharpClient
    {
        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
        public RestResponse restResponse { get; set; }
        public void SetRestClient();
        public void SetRestRequest(RequestType type);
        public void SetRestResponse();
        public Task<RestResponse> GetRestResponse();
    }
}
