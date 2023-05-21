using SpeedyTools.Domain.Models.TicketAggregate;

namespace SpeedyTools.Application.Contracts.Tickets.Responses
{
    public class TicketDto 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Closed { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public Guid AppUserId { get; set; }
    }
}
