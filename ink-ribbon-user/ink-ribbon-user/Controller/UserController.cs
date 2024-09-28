using ink_ribbon_user.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISteamUserSevice _steamUserSevice;

        public UserController(ILogger<UserController> logger, ISteamUserSevice steamUserSevice)
        {
            _logger = logger;
            _steamUserSevice = steamUserSevice;
        }

        [HttpGet("steam/GetUser")]
        public async Task<IActionResult> InsertUser(string steamId)
        {
            //var command = new GetConditionsQuery(assetId);
            var user = await _steamUserSevice.GetSteamUserById(steamId);

            //if (response.IsFailure)
            //    return BadRequest(response.ErrorResponse);

            //if (response.Value == null)
            //    return NoContent();

            return Ok();
        }
    }
}
