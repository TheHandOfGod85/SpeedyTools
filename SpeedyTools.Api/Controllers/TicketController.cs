using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.Tickets.Requests;
using SpeedyTools.Domain.Models.UserAggregate;
using System.Security.Claims;

namespace SpeedyTools.Api.Controllers
{
    [Route("ticket")]
    [ApiController]
    [Authorize]
    public class TicketController : BaseController
    {

        [HttpPost("createTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto createTicketDto)
        {
            var currentUserId = ProcessGetUserId();
            //createTicketDto.AppUserId = currentUserId.Match<IActionResult>()
            var command = createTicketDto.Map();
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
