using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchClips.API.HttpClients
{
    public class DataHttpClient : HttpClient
    {
        public DataHttpClient()
        {
            this.BaseAddress = new Uri("https://api.twitch.tv");
            this.DefaultRequestHeaders.Add("Client-ID", "dlkcnd6tb137reu80zzugsi5xg5fwk");
        }
    }
}
