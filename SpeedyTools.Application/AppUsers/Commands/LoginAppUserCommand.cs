using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;

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

        public LoginAppUserCommandHandler(ITokenService jwt, SignInManager<AppUser> signInManager)
        {
            _jwt = jwt;
            _signInManager = signInManager;
        }

        public async Task<string> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                var appUser = await _signInManager.UserManager.FindByEmailAsync(request.Email);
                var token = _jwt.GenerateTokenString(appUser);
                return token;
            }
            return null;
        }

    }
}
