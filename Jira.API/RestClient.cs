using System.Net;
using Newtonsoft.Json;

namespace Jira.API
{
    public class RestClient
    {
        public string Get(string url)
        {
            using (var webClient = new WebClient())
            {
                var credentials = Credentials.Get();
                webClient.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                return webClient.DownloadString(url);
            }
        }

        public T Get<T>(string url)
        {
            var json = Get(url);
            return Deserialize<T>(json);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
