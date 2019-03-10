using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitchClips.API.Configuration;
using TwitchClips.API.HttpClients;
using TwitchClips.API.Models;

namespace TwitchClips.API.Services
{
    public class TokenService
    {
        private readonly AuthenticationHttpClient _httpClient;

        public TokenService(AuthenticationHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TwitchToken> GetTwitchTokenAsync()
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));
            var result = await _httpClient.PostAsync("oauth2/token?client_id=dlkcnd6tb137reu80zzugsi5xg5fwk&client_secret=od2ff7sxi3zw0kiq8gn8carbjj7wt3&grant_type=client_credentials", content);

            return await result.Content.ReadAsAsync<TwitchToken>();
        }

        private bool IsTokenExpired()
        {
            return false;
        }
    }
}
