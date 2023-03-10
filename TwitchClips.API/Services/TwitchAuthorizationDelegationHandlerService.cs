using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TwitchClips.API.Abstractions;
using TwitchClips.API.Extensions;
using TwitchClips.API.Helper;
using TwitchClips.API.Options;
using TwitchClips.Common.Models;
using GetClipsResponse = TwitchClips.API.Models.Twitch.GetClipsResponse;
using TwitchAuthorizationToken = TwitchClips.API.Models.Twitch.TwitchAuthorizationToken;

namespace TwitchClips.API.Services
{
    public class TwitchApiAuthorizationDelegationHandlerService : ITwitchApiService
    {
        private readonly HttpClient _twitchHttpClient;
        private readonly IOptions<TwitchAuthorizationOptions> _twitchAuthorizationOptions;
        private readonly TwitchApiService _twitchApiService;

        public TwitchApiAuthorizationDelegationHandlerService(HttpClient twitchHttpClient, IOptions<TwitchAuthorizationOptions> twitchAuthorizationOptions, TwitchApiService twitchApiService)
        {
            _twitchHttpClient = twitchHttpClient;
            _twitchAuthorizationOptions = twitchAuthorizationOptions;
            _twitchApiService = twitchApiService;
        }

        public async Task<ClipsResponse> GetTopClipsFromGame(int gameId, int take)
        {
            await PrepareClient();
            return await _twitchApiService.GetTopClipsFromGame(gameId, take);
        }

        public async Task<ClipsResponse> GetClipsFromGame(int gameId, string cursor, int take)
        {
            await PrepareClient();
            return await _twitchApiService.GetClipsFromGame(gameId, cursor, take);
        }

        private async Task PrepareClient()
        {
            var token = await GetToken();

            _twitchHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            _twitchHttpClient.DefaultRequestHeaders.Add("client-id", _twitchAuthorizationOptions.Value.ClientId);
        }

        private async Task<TwitchAuthorizationToken> GetToken()
        {
            var uri = new TwitchUriBuilder("https://id.twitch.tv/oauth2/token")
                .AppendQueryParameter("client_id", _twitchAuthorizationOptions.Value.ClientId)
                .AppendQueryParameter("client_secret", _twitchAuthorizationOptions.Value.ClientSecret)
                .AppendQueryParameter("grant_type", _twitchAuthorizationOptions.Value.GrantType)
                .Build();

            var result = await _twitchHttpClient.PostAsync(uri, null);
            var token = await result.Content.ReadAsAsync<TwitchAuthorizationToken>();

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                throw new Exception("Token is null or empty.");
            }
                
            return token;
        }
    }
}