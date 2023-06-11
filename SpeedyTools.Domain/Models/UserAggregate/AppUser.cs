

using Microsoft.AspNetCore.Identity;
using SpeedyTools.Domain.Models.TicketAggregate;

namespace SpeedyTools.Domain.Models.UserAggregate
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Shift { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
