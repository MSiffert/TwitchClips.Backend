using System;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchClips.API.HttpClients;
using TwitchClips.API.Models;

namespace TwitchClips.API.Services
{
    public class TwitchService
    {
        private readonly DataHttpClient _httpClient;

        public TwitchService(DataHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GameResponse> GetTopGamesAsync()
        {
            var result = await _httpClient.GetAsync("helix/games/top");

            return await result.Content.ReadAsAsync<GameResponse>();
        }

        public async Task<ClipResponse> GetClipsByGameAsync(string gameId)
        {
            var url = $"helix/clips?game_id={gameId}";
            var result = await _httpClient.GetAsync(url);

            return await result.Content.ReadAsAsync<ClipResponse>();
        }

        public async Task<ClipResponse> GetNextClipsByGameAsync(string gameId, string cursor, int take)
        {
            var url = $"helix/clips?game_id={gameId}&after={cursor}&first={take}";
            var result = await _httpClient.GetAsync(url);

            return await result.Content.ReadAsAsync<ClipResponse>();
        }

        public async Task<ClipResponse> GetPreviousClipsByGameAsync(string gameId, string cursor, int take)
        {
            var url = $"helix/clips?game_id={gameId}&before={cursor}&first={take}";
            var result = await _httpClient.GetAsync(url);
            var m = await result.Content.ReadAsStringAsync();
            return await result.Content.ReadAsAsync<ClipResponse>();
        }
    }
}
