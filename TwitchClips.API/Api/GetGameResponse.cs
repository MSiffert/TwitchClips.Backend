using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchClips.API.Api
{
    public class GetGamesApiResponse
    {
        [JsonProperty("data")]
        public List<Game> Data { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
