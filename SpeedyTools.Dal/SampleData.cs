using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Infrastructure
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DataContext>();
            var user = new AppUser
            {
                Name = "Daniele",
                LastName = "Del Piano",
                Email = "dan@test.com",
                NormalizedEmail = "DAN@TEST.COM",
                Shift = "Days",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Pa$$0rd");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var result = userStore.CreateAsync(user);
                context.SaveChangesAsync();
            }
        }
    }
}
