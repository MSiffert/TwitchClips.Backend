using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchClips.API.Abstractions;
using TwitchClips.API.Extensions;
using TwitchClips.API.Helper;
using TwitchClips.Common.Models;
using GetClipsResponse = TwitchClips.API.Models.Twitch.GetClipsResponse;

namespace TwitchClips.API.Services
{
    public class TwitchApiService : ITwitchApiService
    {
        private readonly HttpClient _httpClient;
        
        public TwitchApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ClipsResponse> GetTopClipsFromGame(int gameId, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("first", take)
                .AppendQueryParameter("game_id", gameId)
                .Build();
            
            var response = await _httpClient.GetAsync(uri);
            var getClipsResponse = await response.Content.ReadAsAsync<GetClipsResponse>();

            return new ClipsResponse
            {
                Data = getClipsResponse.Data.Select(e => new Clip
                {
                    Id = e.Id,
                    Language = e.Language,
                    Title = e.Title,
                    Url = e.Url,
                    BroadcasterId = e.BroadcasterId,
                    BroadcasterName = e.BroadcasterName,
                    CreatedAt = e.CreatedAt,
                    CreatorId = e.CreatorId,
                    CreatorName = e.CreatorName,
                    EmbedUrl = e.EmbedUrl,
                    GameId = e.GameId,
                    ThumbnailUrl = e.ThumbnailUrl,
                    VideoId = e.VideoId,
                    ViewCount = e.ViewCount,
                }).ToList(),
                Pagination = new Pagination
                {
                    Cursor = getClipsResponse.Pagination.Cursor
                }
            };
        }
        
        public async Task<ClipsResponse> GetClipsFromGame(int gameId, string cursor, int take)
        {
            var uri = new TwitchUriBuilder("https://api.twitch.tv/helix/clips")
                .AppendQueryParameter("gameId", gameId)
                .AppendQueryParameter("first", take);

            if (!string.IsNullOrEmpty(cursor))
            {
                uri.AppendQueryParameter("after", cursor);
            }

            var response = await _httpClient.GetAsync(uri.Build());
            var getClipsResponse = await response.Content.ReadAsAsync<GetClipsResponse>();

            return new ClipsResponse
            {
                Data = getClipsResponse.Data.Select(e => new Clip
                {
                    Id = e.Id,
                    Language = e.Language,
                    Title = e.Title,
                    Url = e.Url,
                    BroadcasterId = e.BroadcasterId,
                    BroadcasterName = e.BroadcasterName,
                    CreatedAt = e.CreatedAt,
                    CreatorId = e.CreatorId,
                    CreatorName = e.CreatorName,
                    EmbedUrl = e.EmbedUrl,
                    GameId = e.GameId,
                    ThumbnailUrl = e.ThumbnailUrl,
                    VideoId = e.VideoId,
                    ViewCount = e.ViewCount,
                }).ToList(),
                Pagination = new Pagination
                {
                    Cursor = getClipsResponse.Pagination.Cursor
                }
            };
        }
    }
}
