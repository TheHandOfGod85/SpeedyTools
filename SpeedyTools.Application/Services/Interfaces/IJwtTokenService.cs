using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateTokenString(AppUser user);
    }
}