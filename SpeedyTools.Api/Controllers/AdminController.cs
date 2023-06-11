using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.Tickets.Requests;
using SpeedyTools.Api.Filters;
using SpeedyTools.Application.AppUsers.Commands;
using SpeedyTools.Application.AppUsers.Queries;
using SpeedyTools.Application.Contracts.AppUsers.Requests;
using SpeedyTools.Application.Tickets.Commands;
using SpeedyTools.Application.Tickets.Queries;

namespace SpeedyTools.Api.Controllers
{
    [ApiController]
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    [UserId]
    public class AdminController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto createTicketDto)
        {
            createTicketDto.AppUserId = UserId;
            var command = createTicketDto.Map();
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await Mediator.Send(new CreateRoleCommand(roleName));
            return Ok(result);
        }
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery());
            return Ok(result);
        }
        [HttpPost("sendRegistration")]
        public async Task<IActionResult> SendRegistration(SendRegistrationDto sendRegistrationDto )
        {
            var command = sendRegistrationDto.Map();
            var result = await Mediator.Send(command);
            return result ? Ok() : BadRequest("Email already exists");
        }
        [HttpGet("getAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await Mediator.Send(new GetTicketsByAdminQuery());
            return ProcessGet(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteTicketCommand { Id = id, AppUserId = UserId });
            return ProcessDelete(result);
        }
    }
}
