using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers
{
    [Route("ticket")]
    [Authorize]
    public class TicketController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            return Ok("test");
        }
    }
}
