using SpeedyTools.Domain.Models.UserAggregate;


namespace SpeedyTools.Domain.Models.TicketAggregate
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string Title { get;  set; }
        public DateTime Created { get;  set; }
        public DateTime Closed { get; set; }
        public string Description { get;  set; }
        public DateTime LastModified { get;  set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
