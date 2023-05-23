using SpeedyTools.Application.AppUsers.Commands;
using SpeedyTools.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Contracts.AppUsers.Requests
{
    public class SendRegistrationDto : BaseContract<SendRegistrationCommand>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EnumDataType(enumType: typeof(RolesEnum))]
        public RolesEnum Role { get; set; }

        public override SendRegistrationCommand Map()
        {
            return new SendRegistrationCommand { Email = Email, Role = Role };
        }
    }
}
