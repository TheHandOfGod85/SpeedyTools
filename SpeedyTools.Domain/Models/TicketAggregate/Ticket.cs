using SpeedyTools.Domain.Models.UserAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedyTools.Domain.Models.TicketAggregate
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get;  set; }
        public DateTime Created { get;  set; }
        public DateTime Closed { get; set; }
        public string Description { get;  set; }
        public DateTime LastModified { get;  set; }

        [ForeignKey(nameof(Id))]
        public Guid AppUserId { get; set; }
    }
}
