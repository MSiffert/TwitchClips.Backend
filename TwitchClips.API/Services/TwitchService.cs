using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchClips.API.Abstractions;
using TwitchClips.API.Api;
using TwitchClips.API.Extensions;
using TwitchClips.API.Helper;

namespace TwitchClips.API.Services
{
    public class TwitchApiService : ITwitchApiService
    {
        private readonly HttpClient _httpClient;
        
        public TwitchApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<GetClipsResponse> GetTopClipsFromGame(int gameId, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("game_id", gameId)
                .AppendQueryParameter("first", take)
                .Build();
            
            var response = await _httpClient.GetAsync(uri);
            
            return await response.Content.ReadAsAsync<GetClipsResponse>();
        }
        
        public async Task<GetClipsResponse> GetClipsFromGame(int gameId, string cursor, bool isForwardCursor, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("game_id", gameId)
                .AppendQueryParameter("first", take);

            if (!string.IsNullOrEmpty(cursor)) 
                uri.AppendQueryParameter(isForwardCursor ? "after" : "before", cursor);

            var response = await _httpClient.GetAsync(uri.Build());

            return await response.Content.ReadAsAsync<GetClipsResponse>();
        }
        
        public async Task<GetClipsResponse> GetTopClipsFromBroadcaster(int broadcasterId, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("broadcaster_id", broadcasterId)
                .AppendQueryParameter("first", take)
                .Build();
            
            var response = await _httpClient.GetAsync(uri);
            
            return await response.Content.ReadAsAsync<GetClipsResponse>();
        }
        
        public async Task<GetClipsResponse> GetClipsFromBroadcaster(int broadcasterId, string cursor, bool isForwardCursor, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("broadcaster_id", broadcasterId)
                .AppendQueryParameter("first", take);

            if (!string.IsNullOrEmpty(cursor)) 
                uri.AppendQueryParameter(isForwardCursor ? "before" : "after", cursor);

            var response = await _httpClient.GetAsync(uri.Build());

            return await response.Content.ReadAsAsync<GetClipsResponse>();
        }
    }
}
