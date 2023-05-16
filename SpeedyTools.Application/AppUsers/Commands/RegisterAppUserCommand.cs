using MediatR;
using Microsoft.AspNetCore.Identity;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;


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
        private readonly ISendGridService _emailSender;
        public RegisterAppUserCommandHandler
            (
            UserManager<AppUser> userManager
             , ISendGridService emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<string> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            if (_userManager.Users.Any(x => x.Email == request.UserName))
            {
                return null;
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
            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            return emailConfirmationToken.ToString();
        }
    }
}
