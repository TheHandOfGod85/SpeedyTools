using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using System.Text.Json;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class LoginAppUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, string>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _jwt;
        private readonly UserManager<AppUser> _userManager;

        public LoginAppUserCommandHandler(
            ITokenService jwt,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _jwt = jwt;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null) { return null; }
            if (!appUser.EmailConfirmed) { return null; }
            var signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
            if (signInResult.Succeeded)
            {
                var token = _jwt.GenerateTokenString(appUser);
                return JsonSerializer.Serialize(token);
            }
            return null;
        }

    }
}
