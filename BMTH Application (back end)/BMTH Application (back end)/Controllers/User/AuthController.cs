using BusinessLayer.Domain.User;
using BusinessLayer.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.User
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IRegisterService registerService) : ControllerBase
    {
        private readonly IRegisterService _registerService = registerService;

        [HttpPost("register")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RegisterUser([FromBody] Register newUser)
        {
            //var (Success, errors) = _registerService.RegisterUser(newUser);

            //if (!Success)
            //{
            //    return BadRequest(new { Errors = errors });
            //}

            return StatusCode(201);
        }
    }
}
