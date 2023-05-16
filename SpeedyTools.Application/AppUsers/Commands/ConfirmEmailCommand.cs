using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class ConfirmEmailCommand : IRequest<string>
    {
        public ConfirmEmailCommand(string token , string email)
        {
            Token = token;
            Email = email;
        }
        public string Token { get; set; }
        public string Email { get; set; }
    }

    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmEmailCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null) { return null; }
            var result = await _userManager.ConfirmEmailAsync(appUser, request.Token);
            if (result.Succeeded) { return "Thank you for confirming your email."; }
            return "Something went wrong, try again.";
        }
    }
}
