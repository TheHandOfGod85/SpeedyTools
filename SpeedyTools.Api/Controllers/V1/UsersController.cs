using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok($"Version V!");
        }
    }
}
