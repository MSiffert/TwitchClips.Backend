using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitchClips.API.Abstractions;
using TwitchClips.API.Api;
using TwitchClips.API.Services;

namespace TwitchClips.API.Controllers
{
    [Route("games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ITwitchApiService _twitchApiService;

        public GamesController(ITwitchApiService twitchApiService)
        {
            _twitchApiService = twitchApiService;
        }

        [HttpGet]
        [Route("top")]
        [ProducesResponseType(typeof(GetGamesApiResponse), 200)]
        public async Task<IActionResult> GetTopGamesAsync()
        {
            var games = await _twitchApiService.GetTopGames();
            return Ok(games);
        }
    }
}