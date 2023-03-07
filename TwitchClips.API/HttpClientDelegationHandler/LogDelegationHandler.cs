using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchClips.API.HttpClientDelegationHandler
{
    public class LogDelegationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new Exception($"HTTP Request failed. Response: {resultString}");
            }
            
            return response;
        }
    }
}