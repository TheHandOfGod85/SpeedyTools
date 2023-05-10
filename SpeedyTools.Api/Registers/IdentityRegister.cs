using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SpeedyTools.Application.Options;
using System.Text;

namespace SpeedyTools.Api.Registers
{
    public class IdentityRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var jwtSettings = new JwtSettings();
            builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);
            var jwtSection = builder.Configuration.GetSection(nameof(jwtSettings));
            builder.Services.Configure<JwtSettings>(jwtSection);
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SigningKey)),
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudiences = jwtSettings.Audiences,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                };
                opt.Audience = jwtSettings.Audiences[0];
                opt.ClaimsIssuer = jwtSettings.Issuer;
            });
        }
    }
}
