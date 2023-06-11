using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Infrastructure
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            // example how to add a resource configuration
            //new AppUserConfiguration().Configure(builder.Entity<AppUser>());
            //new TicketConfiguration().Configure(builder.Entity<Ticket>());
        }
    }
}
