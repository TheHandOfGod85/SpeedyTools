using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUsers.Requestes;
using SpeedyTools.Application.AppUsers.Commands;

namespace SpeedyTools.Api.Controllers
{
    [Route("user")]
    public class AccountController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAppUser([FromBody] RegisterAppUserDto createAppUserDto)
        {
            var command = createAppUserDto.Map();
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditAppUser([FromBody] EditAppUserDto editAppUserDto,Guid id)
        {
            var command = editAppUserDto.Map();
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await Mediator.Send(new LoginAppUserCommand(email, password));
            return Ok(result);
        }
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await Mediator.Send(new CreateRoleCommand(roleName));
            return Ok(result);
        }
    }
}
