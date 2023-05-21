using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUsers.Requestes;
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
            if (result is null) { return BadRequest("Email already exists"); }
            return Ok(result);
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditAppUser([FromBody] EditAppUserDto editAppUserDto, Guid id)
        {
            var command = editAppUserDto.Map();
            command.Id = id;
            var result = await Mediator.Send(command);
            return ProcessUpdate(result);
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
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await Mediator.Send(new CreateRoleCommand(roleName));
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
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery());
            return Ok(result);
        }
    }
}
