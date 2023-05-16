
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUsers.Requestes;
using SpeedyTools.Application.AppUsers.Commands;

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
        public async Task<IActionResult> EditAppUser([FromBody] EditAppUserDto editAppUserDto,Guid id)
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
            if(result is null) { return BadRequest("Wrong email or password"); }
            return Ok(result);
        }
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await Mediator.Send(new CreateRoleCommand(roleName));
            return Ok(result);
        }
        [HttpGet("confirmAccount")]
        public async Task<IActionResult> ConfirmAccount(string token, string email)
        {
            var result = await Mediator.Send(new ConfirmEmailCommand(token, email));
            if(result is null) { return NotFound("Email not found"); }
            return Ok(result);
        }
    }
}
