using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Contracts.AppUserS.Responses;
using SpeedyTools.Application.Exceptions;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class LoginAppUserCommand : IRequest<string>
    {
        public LoginAppUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _jwt;

        public LoginAppUserCommandHandler(UserManager<AppUser> userManager, IJwtTokenService jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<string> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            
            var result = await _userManager.CheckPasswordAsync(appUser, request.Password);
            var token = _jwt.GenerateTokenString(appUser);
            return token;
        }

    }
}
