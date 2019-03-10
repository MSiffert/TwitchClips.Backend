using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitchClips.API.Models;
using TwitchClips.API.Services;

namespace TwitchClips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly TwitchService _twitchService;

        public TokenController(TokenService tokenService, TwitchService twitchService)
        {
            _tokenService = tokenService;
            _twitchService = twitchService;
        }

        [HttpGet]
        [Route("token")]
        public async Task<IActionResult> GetTokenAsync()
        {
            var token = await _tokenService.GetTwitchTokenAsync();
            return Ok(token);
        }

        [HttpGet]
        [Route("games/top")]
        [ProducesResponseType(typeof(GameResponse), 200)]
        public async Task<IActionResult> GetTopGamesAsync()
        {
            var games = await _twitchService.GetTopGamesAsync();
            return Ok(games);
        }

        [HttpGet]
        [Route("clips")]
        [ProducesResponseType(typeof(ClipResponse), 200)]
        public async Task<IActionResult> GetClipsByGameAsync([FromQuery]string gameId)
        {
            var clips = await _twitchService.GetClipsByGameAsync(gameId);

            return Ok(clips);
        }

        [HttpGet]
        [Route("clips/next")]
        [ProducesResponseType(typeof(ClipResponse), 200)]
        public async Task<IActionResult> GetNextClipsByGameAsync([FromQuery]string gameId, [FromQuery]string cursor, [FromQuery]int take)
        {
            var clips = await _twitchService.GetNextClipsByGameAsync(gameId, cursor, take);
            return Ok(clips);
        }

        [HttpGet]
        [Route("clips/before")]
        [ProducesResponseType(typeof(ClipResponse), 200)]
        public async Task<IActionResult> GetPreviousClipsByGameAsync([FromQuery]string gameId, [FromQuery]string cursor, [FromQuery]int take)
        {
            var clips = await _twitchService.GetPreviousClipsByGameAsync(gameId, cursor, take);
            return Ok(clips);
        }
    }
}