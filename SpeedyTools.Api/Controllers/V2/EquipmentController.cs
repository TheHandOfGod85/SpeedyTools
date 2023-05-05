using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok("Version V2");
        }
    }
}
