﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Infrastructure
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DataContext>();
            // Seed User
            var user = new AppUser
            {
                Id = "2b49f544-7ced-4cff-bc9c-e223f6059cf4",
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

            // Seed ticket
            if (!context.Tickets.Any())
            {
                var ticket = new Ticket
                {
                    Id = Guid.Parse("b29f76fa-7af0-433c-c795-08db5a29420a"),
                    Title = "Sample Ticket",
                    Created = DateTime.Now,
                    Description = "This is a sample ticket.",
                    AppUserId = Guid.Parse("2b49f544-7ced-4cff-bc9c-e223f6059cf4") // Assign the ticket to the seeded user
                };

                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
                
        }
    }
}
