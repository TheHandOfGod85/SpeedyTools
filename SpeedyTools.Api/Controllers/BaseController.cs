using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Api.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        private  UserManager<AppUser> _userManager;
        
        protected UserManager<AppUser> userManager =>
            _userManager ??= HttpContext.RequestServices.GetService<UserManager<AppUser>>();
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
       .GetService<IMediator>();

        protected ActionResult ProcessUpdate(bool result)
        {
            return result ? NoContent() : NotFound();
        }
        protected OneOf<Guid, ActionResult> ProcessGetUserId()
        {
            var currentUserId = Guid.Parse(_userManager.GetUserId(User));
            if (currentUserId == null) { return Unauthorized(); }
            return currentUserId;
        }
    }
}
