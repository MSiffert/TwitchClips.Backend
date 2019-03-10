using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchClips.API.Models
{
    public class GameResponse
    {
        public List<Game> data { get; set; }
        public Pagination pagination { get; set; }
    }
}
