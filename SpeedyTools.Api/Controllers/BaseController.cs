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

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
       .GetService<IMediator>();

        protected Guid UserId => (Guid)HttpContext.Items["UserId"];

        protected ActionResult ProcessUpdate(bool result)
        {
            return result ? NoContent() : NotFound();
        }
        protected ActionResult ProcessGet<T>(T result)
        {
            return result is not null ? Ok(result) : NotFound();
        }
        protected ActionResult ProcessDelete(bool result)
        {
            return result ? NoContent() : NotFound();
        }
        
    }
}
