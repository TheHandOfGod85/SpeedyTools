using SpeedyTools.Application.AppUsers.Commands;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.Requestes
{
    public class CreateAppUserDto : BaseContract<CreateAppUserCommand>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Shift { get; set; }

        public override CreateAppUserCommand Map()
        {
            return new CreateAppUserCommand { Name = Name, LastName = LastName, Shift = Shift };
        }
    }
}
