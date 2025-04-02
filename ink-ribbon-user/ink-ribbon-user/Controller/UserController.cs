using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    [EnableCors("All")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("User/InsertUser")]
        public async Task<IActionResult> InsertUser(User user)
        {
            await _userService.Insert(user);

            return Ok(user);
        }
    }
}
