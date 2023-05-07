using SpeedyTools.Api.Extensions;

namespace SpeedyTools.Api.Registers
{
    public class DataAccessRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {

            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            builder.Services.AddDataContext(configuration);
            builder.Services.AddRepositories();
            builder.Services.AddUnitsOfWork();
        }
    }
}
