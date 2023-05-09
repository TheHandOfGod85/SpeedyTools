using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Contracts;
using SpeedyTools.Domain.Interfaces.Repositories;

namespace SpeedyTools.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = unitOfWork.AppUser.GetAll();
            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = unitOfWork.AppUser.Get(id);
            if (user is null) return NotFound("User not found");
            return Ok(user);    
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = createUserDto.Map();
            unitOfWork.AppUser.Add(user);
            unitOfWork.Complete();
            return Ok(createUserDto);
        }
        [HttpDelete]
        public IActionResult DeleteUserById(Guid id)
        {
            var user = unitOfWork.AppUser.Get(id);
            if (user is null) return NotFound("User not found");
            unitOfWork.AppUser.Remove(user);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
