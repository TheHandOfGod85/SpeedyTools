using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SpeedyTools.Api.Registers
{
    public class MvcWebAppRegister : IWebApplicationRegister
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.MapControllers();
        }
    }
}
