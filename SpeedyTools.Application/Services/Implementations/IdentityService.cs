using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Contracts.Requests;
using SpeedyTools.Application.Contracts.Responses;
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

        public async Task<ServiceResult<string>> RegisterUser(RegisterUserDto register)
        {
            ServiceResult<string> result = new();
            try
            {
                var identityUser = new AppUser
                {
                    UserName = register.username
                };
                 await _userManager.CreateAsync(identityUser);
                result.Payload = $"User {register.username} was created successfully, email was sent to {register.username}";

            }
            catch (Exception ex)
            {
                result.IsError = true ;
                result.ErrorMessage = ex.Message ;
            }

            
            
           await _emailSender.SendEmailAsync(register.username, "<p>An acccount was created form you</p>","Account Created");

            return result;
        }
    }
}
