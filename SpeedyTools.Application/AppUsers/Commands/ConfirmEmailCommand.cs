using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Services.Interfaces;
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
        private readonly IEncoderService _encoderService;
        public ConfirmEmailCommandHandler(UserManager<AppUser> userManager, IEncoderService encoderService)
        {
            _userManager = userManager;
            _encoderService = encoderService;
        }
        public async Task<string> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null) { return null; }
            var decodedToken = _encoderService.Decode(request.Token);
            var result = await _userManager.ConfirmEmailAsync(appUser, decodedToken);
            if (result.Succeeded) { return "Email confirmed, you can now login."; }
            return "Could not verify email address.";
        }
    }
}
