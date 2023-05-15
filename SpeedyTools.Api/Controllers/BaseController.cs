using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
       .GetService<IMediator>();

        protected ActionResult ProcessUpdate(bool result)
        {
            return result ? NoContent() : NotFound();
        }
    }
}
