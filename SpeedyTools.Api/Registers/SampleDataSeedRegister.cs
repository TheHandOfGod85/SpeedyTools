using SpeedyTools.Infrastructure;

namespace SpeedyTools.Api.Registers
{
    public class SampleDataSeedRegister : IWebApplicationRegister
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                SampleData.Initialize(serviceProvider);
            }
        }
    }
}
