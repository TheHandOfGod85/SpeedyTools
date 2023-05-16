using Microsoft.AspNetCore.Mvc;

namespace SpeedyTools.Api.Registers
{
    public class MvcRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(config =>
            {
                //config.Filters.Add(typeof(ValidateModelFilter));
            });
            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                //config.SuppressModelStateInvalidFilter = true;
            });
            
            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
