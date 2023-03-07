using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitchClips.API.Abstractions;
using TwitchClips.API.Api;
using GetClipsResponse = TwitchClips.API.Models.Twitch.GetClipsResponse;

namespace TwitchClips.API.Controllers
{
    [Route("clips")]
    [ApiController]
    public class ClipsController : ControllerBase
    {
        private readonly ITwitchApiService _twitchApiService;

        public ClipsController(ITwitchApiService twitchApiService)
        {
            _twitchApiService = twitchApiService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetClipsResponse), 200)]
        public async Task<IActionResult> GetClipsByGameAsync([FromQuery]int gameId, [FromQuery] int take = 10)
        {
            var clips = await _twitchApiService.GetTopClipsFromGame(gameId, take);

            return Ok(clips);
        }
        
        [HttpGet]
        [Route("next")]
        [ProducesResponseType(typeof(GetClipsResponse), 200)]
        public async Task<IActionResult> GetNextClipsByGameAsync([FromQuery]int gameId, [FromQuery] string cursor, [FromQuery] int take = 10)
        {
            var clips = await _twitchApiService.GetClipsFromGame(gameId, cursor, take);

            return Ok(clips);
        }
    }
}