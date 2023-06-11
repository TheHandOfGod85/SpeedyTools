using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.Tickets.Requests;
using SpeedyTools.Api.Filters;
using SpeedyTools.Application.Tickets.Commands;
using SpeedyTools.Application.Tickets.Queries;

namespace SpeedyTools.Api.Controllers
{
    [Route("ticket")]
    [ApiController]
    [Authorize]
    [UserId]
    public class TicketController : BaseController
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto createTicketDto)
        {
            createTicketDto.AppUserId = UserId;
            var command = createTicketDto.Map();
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("edit")]
        public async Task<IActionResult> Update([FromBody] EditTicketDto editTicketDto)
        {
            var command = editTicketDto.Map();
            command.AppUserId = UserId;
            var result = await Mediator.Send(command);
            return ProcessUpdate(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var query = new GetTicketByAppUserQuery { Id = id, AppUserId = UserId };
            var result = await Mediator.Send(query);
            return ProcessGet(result);
        }
        
        
        [HttpGet("userTickets")]
        public async Task<IActionResult> GetUserTickets()
        {
            var query = await Mediator.Send( new GetTicketsByAppUserQuery { Id = UserId });
            return ProcessGet(query);
        }
    }
}
