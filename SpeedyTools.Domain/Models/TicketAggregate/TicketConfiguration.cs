using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedyTools.Domain.Models.TicketAggregate
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            //builder.HasOne(t => t.AppUser)
            //.WithMany(u => u.Tickets)
            //.HasForeignKey(t => t.AppUserId);
        }
    }
}
