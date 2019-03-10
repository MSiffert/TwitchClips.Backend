using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchClips.API.HttpClients
{
    public class AuthenticationHttpClient : HttpClient
    {
        public AuthenticationHttpClient()
        {
            this.BaseAddress = new Uri("https://id.twitch.tv");
        }
    }
}
