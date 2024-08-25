using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger) { _logger = logger; }

        [HttpGet("partial-redemption/conditions")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetUser()
        {
            //var command = new GetConditionsQuery(assetId);
            //var response = await _sender.Send(command);

            //if (response.IsFailure)
            //    return BadRequest(response.ErrorResponse);

            //if (response.Value == null)
            //    return NoContent();

            return Ok();
        }

        [HttpGet("partial-redemption/conditions")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public IActionResult InsertUser()
        {
            //var command = new GetConditionsQuery(assetId);
            //var response = await _sender.Send(command);

            //if (response.IsFailure)
            //    return BadRequest(response.ErrorResponse);

            //if (response.Value == null)
            //    return NoContent();

            return Ok();
        }
    }
}
