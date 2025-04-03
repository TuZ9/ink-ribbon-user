using ink_ribbon_user.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    [EnableCors("All")]
    public class SteamUserController : ControllerBase
    {
        private readonly ISteamUserSevice _steamUserSevice;

        public SteamUserController(ISteamUserSevice steamUserSevice)
        {
            _steamUserSevice = steamUserSevice;
        }

        [HttpGet("steam/GetSteamIdByName")]
        public async Task<IActionResult> GetSteamIdByName(string steamName)
        {
            var user = await _steamUserSevice.GetSteamIdByName(steamName);
            return Ok(user);
        }

        [HttpGet("steam/GetUser")]
        public async Task<IActionResult> GetSteamUserById(string steamId)
        {
            var user = await _steamUserSevice.GetSteamUserById(steamId);

            return Ok(user);
        }
    }
}