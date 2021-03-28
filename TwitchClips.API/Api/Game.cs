using Newtonsoft.Json;

namespace TwitchClips.API.Api
{
    public class Game
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("box_art_url")]
        public string BoxArtUrl { get; set; }
    }
}