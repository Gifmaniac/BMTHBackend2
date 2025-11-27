using Azure;
using BusinessLayer.Domain.User;
using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Mapper.ApiMapper.Auth;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.User
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IRegisterService registerService, ILoginService loginService, JwtTokenGenerator tokenGenerator) : ControllerBase
    {
        private readonly IRegisterService _registerService = registerService;
        private readonly ILoginService _loginService = loginService;
        private readonly JwtTokenGenerator _tokenGenerator = tokenGenerator;

        [HttpPost("register")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto newUser)
        { 
            AuthResponseDto response = await _registerService.RegisterUser(newUser);

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
            AuthLoginResponseDto response = await _loginService.LoginUser(givenUserDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
