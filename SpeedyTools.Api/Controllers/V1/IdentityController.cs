using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.Identity;
using SpeedyTools.Application.Services.Interfaces;

namespace SpeedyTools.Api.Controllers.V1
{
    [ApiController]
    //[Authorize]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegistration register)
        {
            var username = register.Map();
            var result = await _identityService.RegisterUser(username);
            return Ok(result);
        }
    }
}
