using SpeedyTools.Application.Contracts.Requests;
using SpeedyTools.Domain.Models.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.Identity
{
    public class UserRegistration : BaseContract<RegisterUserDto>
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        public override RegisterUserDto Map()
        {
            return new RegisterUserDto(Username);
        }
    }
}
