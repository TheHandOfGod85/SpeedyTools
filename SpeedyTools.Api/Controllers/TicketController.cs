using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.Tickets.Requests;
using SpeedyTools.Application.Tickets.Commands;
using SpeedyTools.Application.Tickets.Queries;

namespace SpeedyTools.Api.Controllers
{
    [Route("ticket")]
    [ApiController]
    [Authorize]
    public class TicketController : BaseController
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto createTicketDto)
        {
            var userId = UserManager.GetUserId(User);
            if (userId == null) { return Unauthorized(); }
            createTicketDto.AppUserId = Guid.Parse(userId);
            var command = createTicketDto.Map();
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] EditTicketDto editTicketDto)
        {
            var command = editTicketDto.Map();
            var result = await Mediator.Send(command);
            return ProcessUpdate(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var query = new GetTicketQuery { Id = id };
            var result = await Mediator.Send(query);
            return ProcessGet(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetTicketsQuery());
            return ProcessGet(result);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteTicketCommand { Id = id });
            return ProcessDelete(result);
        }
        [HttpGet("userTickets")]
        public async Task<IActionResult> GetUserTickets()
        {
            var userId = UserManager.GetUserId(User);
            if (userId == null) { return Unauthorized(); }
            var query = await Mediator.Send( new GetAppUserTicketsQuery { Id = Guid.Parse(userId) });
            return ProcessGet(query);
        }
    }
}
