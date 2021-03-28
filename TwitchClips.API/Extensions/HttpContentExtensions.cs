using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchClips.API.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<TType> ReadAsAsync<TType>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<TType>(await content.ReadAsStringAsync());
        }
    }
}