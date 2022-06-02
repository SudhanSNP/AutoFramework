using Newtonsoft.Json;

namespace Helpers.Json
{
    public class JsonHelper
    {
        public static async Task<T> JsonDeserializeAsync<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
