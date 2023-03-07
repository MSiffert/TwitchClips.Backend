using System.Collections.Generic;
using Newtonsoft.Json;
using TwitchClips.API.Api;

namespace TwitchClips.API.Models.Twitch
{
    public class GetClipsResponse
    {
        [JsonProperty("data")]
        public List<Models.Twitch.Clip> Data { get; set; }
        
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
