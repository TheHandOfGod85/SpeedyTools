using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.DataAccess
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

            //new AppUserConfiguration().Configure(builder.Entity<AppUser>());
        }
    }
}
