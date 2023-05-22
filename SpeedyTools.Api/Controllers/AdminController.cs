using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts.AppUsers.Requestes;
using SpeedyTools.Application.AppUsers.Commands;
using SpeedyTools.Application.AppUsers.Queries;

namespace SpeedyTools.Api.Controllers
{
    [ApiController]
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        

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

        // Todo: Create a method to send an email that invites for registration.
        // The email will have a registration page, the admin that sends the email
        // will assign the role to the new user
    }
}
