using Microsoft.AspNetCore.Mvc;
using SpeedyTools.Api.Filters;

namespace SpeedyTools.Api.Registers
{
    public class MvcRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(config =>
            {
                config.Filters.Add(typeof(ExceptionFilter));
            });
            
            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
