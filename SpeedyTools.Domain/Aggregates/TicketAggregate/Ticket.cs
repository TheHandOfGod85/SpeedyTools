using SpeedyTools.Domain.Aggregates.UserAggregate;


namespace SpeedyTools.Domain.Aggregates.TicketAggregate
{
    public class Ticket
    {
        public Guid TicketId { get; private set; }
        public string Title { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Closed { get; private set; }
        public string Description { get; private set; }
        public DateTime LastModified { get; private set; }
        public Guid AppUserId { get; private set; }
        public AppUser AppUser { get; private set; }
    }
}
