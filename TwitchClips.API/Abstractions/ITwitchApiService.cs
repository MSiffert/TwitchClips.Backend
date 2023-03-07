﻿using System.Threading.Tasks;
using TwitchClips.API.Api;
using GetClipsResponse = TwitchClips.API.Models.Twitch.GetClipsResponse;

namespace TwitchClips.API.Abstractions
{
    public interface ITwitchApiService
    {
        Task<ClipsResponse> GetTopClipsFromGame(int gameId, int take);
        Task<ClipsResponse> GetClipsFromGame(int gameId, string cursor, int take);
    }
}