using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUsers.Requestes;
using SpeedyTools.Api.Filters;
using SpeedyTools.Application.AppUsers.Commands;
using SpeedyTools.Application.AppUsers.Queries;

namespace SpeedyTools.Api.Controllers
{
    [AllowAnonymous]
    [Route("user/")]
    public class AccountController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAppUser([FromBody] RegisterDto createAppUserDto)
        {
            var command = createAppUserDto.Map();
            var result = await Mediator.Send(command);
            if (result is null) { return BadRequest("Email was not registered"); }
            return Ok(result);
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command = loginDto.Map();
            var result = await Mediator.Send(command);
            if (result is "Wrong") { return BadRequest("Wrong email or password"); }
            if (result is null) { return Unauthorized("Please, confirm your email"); }
            return Ok(result);
        }
        
        [HttpGet("verifyEmail")]
        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            var result = await Mediator.Send(new ConfirmEmailCommand(token, email));
            if (result is null) { return BadRequest(result); }
            return Ok(result);
        }
        [HttpGet("resendEmailConfirmationLink")]
        public async Task<IActionResult> ResendEmailConfirmationLink(string email)
        {
            var result = await Mediator.Send(new ResendConfirmationEmailCommand(email));
            if (result is null) { return Unauthorized(); }
            return Ok(result);
        }
        [Authorize]
        [HttpPut("edit")]
        [UserId]
        public async Task<IActionResult> EditAppUser([FromBody] EditAppUserDto editAppUserDto)
        {
            var command = editAppUserDto.Map();
            command.AppUserId = UserId;
            var result = await Mediator.Send(command);
            return ProcessUpdate(result);
        }

    }
}
