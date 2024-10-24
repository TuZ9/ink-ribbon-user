using ink_ribbon_user.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    [EnableCors("All")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISteamUserSevice _steamUserSevice;
        private readonly IXboxUserService _xboxUserService;

        public UserController(ILogger<UserController> logger, ISteamUserSevice steamUserSevice, IXboxUserService xboxUserService)
        {
            _logger = logger;
            _steamUserSevice = steamUserSevice;
            _xboxUserService = xboxUserService;
        }

        [HttpGet("steam/GetSteamIdByName")]
        public async Task<IActionResult> GetSteamIdByName(string steamName)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _steamUserSevice.BuildSteamUser(steamName);
            return Ok(user);
        }

        [HttpGet("steam/GetUser")]
        public async Task<IActionResult> GetSteamUserById(string steamId)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _steamUserSevice.GetSteamUserById(steamId);

            return Ok(user);
        }

        [HttpGet("Xbox/GetXboxUser")]
        public async Task<IActionResult> GetXboxUser(string gamertag)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _xboxUserService.GetUserByGameTag(gamertag);

            return Ok(user);
        }

        [HttpGet("Xbox/GetXboxLastSeen")]
        public async Task<IActionResult> GetXboxLastSeen(string xuid)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _xboxUserService.GetLastSeenStatus(xuid);

            return Ok(user);
        }
    }
}