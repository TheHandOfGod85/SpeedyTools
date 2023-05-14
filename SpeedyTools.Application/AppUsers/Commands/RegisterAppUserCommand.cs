using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Services.Implementations;
using SpeedyTools.DataAccess;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class RegisterAppUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }


    public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly JwtTokenService _jwtTokenService;
        public RegisterAppUserCommandHandler
            (
            UserManager<AppUser> userManager
            //JwtTokenService jwtTokenService
            )
        {
            _userManager = userManager;
            //_jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            if (_userManager.Users.Any(x => x.Email == request.UserName))
            {
                throw new Exception("Email already exist");
            }
            var appUser = new AppUser
            {
                Email = request.UserName,
                UserName = request.UserName,
                Name = request.Name,
                LastName = request.LastName,
                Shift = request.Shift,
            };
            var result = await _userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded) { throw new Exception(message: $"{result.Errors.FirstOrDefault().Description}"); }
            return appUser.Id;
        }
    }
}
