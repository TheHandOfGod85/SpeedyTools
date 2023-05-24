using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SpeedyTools.Api.Middleware;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Api.Registers
{
    public class MvcWebAppRegister : IWebApplicationRegister
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();
        }
    }
}
