using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Contracts;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.DataAccess.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;


        public IdentityService(UserManager<AppUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<string> RegisterUser(RegisterUserDto register)
        {
            var identityUser = new AppUser
            {
                UserName = register.username
            };
            var result = await _userManager.CreateAsync(identityUser);
            if (!result.Succeeded)
            {
                throw new Exception("User not created");
            }
           await _emailSender.SendEmailAsync(register.username, "<p>An acccount was created form you</p>","Account Created");
            return $"User {register.username} was created successfully, email was sent to {register.username}";
        }
    }
}
