using Microsoft.EntityFrameworkCore;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .Property(appuser => appuser.Role)
                .HasConversion<string>();
        }
    }
}
