using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchClips.API.Api
{
    public class GetClipsResponse
    {
        [JsonProperty("data")]
        public List<Clip> Data { get; set; }
        
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
