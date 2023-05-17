using SpeedyTools.Application.Services.Interfaces;

namespace SpeedyTools.Api.Services.Implementations
{
    public class WebApiContextService : IApiContextAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public WebApiContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetOrigin()
        {
           var  origin = httpContextAccessor.HttpContext.Request.Headers["origin"];
            return origin;
        }
    }
}
