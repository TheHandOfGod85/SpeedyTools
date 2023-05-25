using SpeedyTools.Application.AppUsers.Commands;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.AppUsers.Requestes
{
    public class LoginDto : BaseContract<LoginAppUserCommand>
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public override LoginAppUserCommand Map()
        {
            return new LoginAppUserCommand { Email = Email, Password = Password };
        }
    }
}
