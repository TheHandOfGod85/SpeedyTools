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
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
        ErrorMessage =
        "Has minimum 8 characters in length\r\n" +
        "At least one uppercase English letter\r\n" +
        "At least one lowercase English letter\r\n" +
        "At least one digit\r\n" +
        "At least one special character")]
        public string Password { get; set; }
        public override LoginAppUserCommand Map()
        {
            return new LoginAppUserCommand { Email = Email, Password = Password };
        }
    }
}
