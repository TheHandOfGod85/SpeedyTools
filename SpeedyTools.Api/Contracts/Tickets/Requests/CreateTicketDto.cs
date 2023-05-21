using SpeedyTools.Application.Tickets.Commands;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.Tickets.Requests
{
    public class CreateTicketDto : BaseContract<CreateTicketCommand>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid AppUserId { get; set; }

        public override CreateTicketCommand Map()
        {
            return new CreateTicketCommand { Title = Title, Description = Description, AppUserId = AppUserId };
        }
    }
}
