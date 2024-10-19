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

        public UserController(ILogger<UserController> logger, ISteamUserSevice steamUserSevice)
        {
            _logger = logger;
            _steamUserSevice = steamUserSevice;
        }

        [HttpGet("steam/GetSteamIdByName")]
        public async Task<IActionResult> GetSteamIdByName(string steamName)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _steamUserSevice.GetSteamIdByName(steamName);
            return Ok(user);
        }

        [HttpGet("steam/GetUser")]
        public async Task<IActionResult> GetSteamUserById(string steamId)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _steamUserSevice.GetSteamUserById(steamId);

            return Ok(user);
        }
    }
}
