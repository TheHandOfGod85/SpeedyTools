using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Enums;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{

    public class SendRegistrationCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public RolesEnum Role { get; set; }
    }
    public class SendRegistrationCommandHandler : IRequestHandler<SendRegistrationCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailSender;
        private readonly IApiContextAccessor _contextAccessor;

        public SendRegistrationCommandHandler(
            IApiContextAccessor contextAccessor,
            IEmailService emailSender,
            UserManager<AppUser> userManager)
        {
            _contextAccessor = contextAccessor;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task<bool> Handle(SendRegistrationCommand request, CancellationToken cancellationToken)
        {
            if (_userManager.Users.Any(x => x.Email == request.Email))
            {
                return false;
            }
            AppUser appUser = CreateUser(request);
            var result = await _userManager.CreateAsync(appUser);
            if (!result.Succeeded) { throw new Exception(message: $"{result.Errors.FirstOrDefault().Description}"); }
            await _userManager.AddToRoleAsync(appUser, request.Role.ToString());
            var origin = _contextAccessor.GetOrigin();
            var registerUrl = $"{origin}/user/register";
            await _emailSender.SendEmailAsync(appUser.UserName, "Please verify email",
                "<h1>Welcome to SpeedyTools</h1>" +
                "<p>You have invited to sign up to the SpeedyTools</p>" +
                $"<p>The email to complete the registration is {appUser.Email}</p>" +
                $"<p>Please click the below link to verify your email address:</p><p><a href='{registerUrl}'>Click to verify email</a></p>");
            return true;
        }

        private static AppUser CreateUser(SendRegistrationCommand request)
        {
            return new AppUser
            {
                Email = request.Email,
                UserName = request.Email
            };
        }
    }
}
