using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        SecurityToken CreateSecurityToken(ClaimsIdentity identity);
        string WriteToken(SecurityToken token);
    }
}