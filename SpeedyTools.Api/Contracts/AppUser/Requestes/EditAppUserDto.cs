using SpeedyTools.Application.AppUsers.Commands;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.AppUser.Requestes
{
    public class EditAppUserDto : BaseContract<EditAppUserCommand>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }



        public override EditAppUserCommand Map()
        {
            return new EditAppUserCommand
            {
               Name = Name,
               LastName = LastName,
               Shift = Shift
            };
        }
    }
}
