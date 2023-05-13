using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUser.Requestes;
using SpeedyTools.Api.Contracts.Requestes;

namespace SpeedyTools.Api.Controllers
{
    [Route("user")]
    public class AppUserController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppUser([FromBody] CreateAppUserDto createAppUserDto)
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
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
