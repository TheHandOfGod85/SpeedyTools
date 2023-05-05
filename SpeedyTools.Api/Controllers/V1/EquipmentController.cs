using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Version V{id}!");
        }
    }
}
