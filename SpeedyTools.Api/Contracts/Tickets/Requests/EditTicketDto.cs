using SpeedyTools.Application.Tickets.Commands;
using System.ComponentModel.DataAnnotations;

namespace SpeedyTools.Api.Contracts.Tickets.Requests
{
    public class EditTicketDto : BaseContract<EditTicketCommand>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid AppUserId { get; set; }

        public override EditTicketCommand Map()
        {
            return new EditTicketCommand 
            { 
                Id = Id, 
                Title = Title, 
                Description = Description,
                AppUserId = AppUserId 
            };
        }
    }
}
