namespace SpeedyTools.Api.Registers
{
    public class LoggerRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }
    }
}
