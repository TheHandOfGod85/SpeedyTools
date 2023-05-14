using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Contracts.AppUserS.Responses;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class LoginAppUserCommand : IRequest<AppUserDto>
    {
        public LoginAppUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, AppUserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        public LoginAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUserDto> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null)
            {
                throw new Exception("Email was not found");
            }
            var result = await _userManager.CheckPasswordAsync(appUser, request.Password);
            if (result)
            {
                return new AppUserDto
                {
                    Email = appUser.Email,
                    Name = appUser.Name,
                    LastName = appUser.LastName,
                    Shift = appUser.Shift
                };
            }
            else
            {
                throw new Exception("Password was incorrect");
            }
        }

    }
}
