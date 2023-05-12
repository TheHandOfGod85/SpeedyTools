
namespace SpeedyTools.Api.Registers
{
    public class SwaggerRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
        }
    }
}
