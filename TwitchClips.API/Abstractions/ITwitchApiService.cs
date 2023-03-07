using System.Threading.Tasks;
using TwitchClips.API.Api;

namespace TwitchClips.API.Abstractions
{
    public interface ITwitchApiService
    {
        Task<GetClipsResponse> GetTopClipsFromGame(int gameId, int take);
        Task<GetClipsResponse> GetClipsFromGame(int gameId, string cursor, bool isForwardCursor, int take);
    }
}