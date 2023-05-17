using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateTokenString(AppUser user);
    }
}