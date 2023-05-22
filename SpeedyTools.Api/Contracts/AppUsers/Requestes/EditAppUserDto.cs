using SpeedyTools.Application.AppUsers.Commands;

namespace SpeedyTools.Api.Contracts.AppUsers.Requestes
{
    public class EditAppUserDto : BaseContract<EditAppUserCommand>
    {
        public Guid AppUserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Shift { get; set; }



        public override EditAppUserCommand Map()
        {
            return new EditAppUserCommand
            {
               AppUserId = AppUserId,
               Name = Name,
               LastName = LastName,
               Shift = Shift
            };
        }
    }
}
