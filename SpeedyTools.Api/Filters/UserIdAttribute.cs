using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace SpeedyTools.Api.Filters
{
    public class UserIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            context.HttpContext.Items["UserId"] = Guid.Parse(userId);
        }
    }
}
