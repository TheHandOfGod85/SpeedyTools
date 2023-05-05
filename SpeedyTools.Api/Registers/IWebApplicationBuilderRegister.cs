namespace SpeedyTools.Api.Registers
{
    public interface IWebApplicationBuilderRegister : IRegister
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
