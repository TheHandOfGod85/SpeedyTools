using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers
{
    
    public class TicketController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTicket()
        {
            return Ok();
        }
    }
}
