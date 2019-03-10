using Newtonsoft.Json;

namespace TwitchClips.API.Models
{
    public class TwitchToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; }

        [JsonProperty("scope")]
        public string Scope { get; }

        [JsonProperty("token_type")]
        public string TokenType { get; }
    }
}
