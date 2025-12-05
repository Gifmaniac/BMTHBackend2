using BusinessLayer.Interfaces.User;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BMTHApplication.BackEnd.Controllers.User

{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IRegisterService registerService, ILoginService loginService) : ControllerBase
    {
        private readonly IRegisterService _registerService = registerService;
        private readonly ILoginService _loginService = loginService;

        [HttpPost("register")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto newUser)
        { 
            AuthResponseDto response = await _registerService.RegisterUser(newUser).ConfigureAwait(false);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return StatusCode(201, response);
        }

        [HttpPost("login")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto givenUserDto)
        {
            AuthLoginResponseDto response = await _loginService.LoginUser(givenUserDto).ConfigureAwait(false);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            if (response.Token is null)
            {
                throw new InvalidOperationException("Generated token cannot be null.");
            }

            Response.Cookies.Append("jwt", response.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return Ok(response);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Append("jwt", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow
            });

            return Ok(new { message = "Logged out" });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new
            {
                userId,
                email,
                role
            });
        }
    }
}
