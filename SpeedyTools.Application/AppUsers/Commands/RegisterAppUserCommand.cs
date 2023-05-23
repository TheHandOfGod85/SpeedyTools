using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;


namespace SpeedyTools.Application.AppUsers.Commands
{
    public class RegisterAppUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }


    public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailSender;
        private readonly IEncoderService _encoderService;
        private readonly IApiContextAccessor _contextAccessor;
        private readonly IHtmlProcessor _htmlProcessor;
        private readonly IWebRootPathBuilder _rootPathBuilder;

        public RegisterAppUserCommandHandler
            (
            UserManager<AppUser> userManager,
               IEmailService emailSender,
               IEncoderService encoderService,
               IApiContextAccessor contextAccessor,
               IWebRootPathBuilder rootPathBuilder,
               IHtmlProcessor htmlProcessor)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _encoderService = encoderService;
            _contextAccessor = contextAccessor;
            _rootPathBuilder = rootPathBuilder;
            _htmlProcessor = htmlProcessor;
        }

        public async Task<string> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            var userInvited = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (userInvited is null) { return null; }
            string passwordHashed = HashPassword(request, userInvited);
            CompleteRegistration(request, userInvited, passwordHashed);
            var result = await _userManager.UpdateAsync(userInvited);
            if (!result.Succeeded) { throw new Exception(message: $"{result.Errors.FirstOrDefault().Description}"); }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(userInvited);
            var encodedToken = _encoderService.Encode(token);
            var origin = _contextAccessor.GetOrigin();
            var verifyUrl = $"{origin}/user/verifyEmail?token={encodedToken}&email={userInvited.Email}";
            var pathToFile = _rootPathBuilder.GetWebRootPath("Templates", "EmailConfirmationTemplate.html");
            List<string> replacements = new List<string> { request.Email, verifyUrl, verifyUrl };
            string htmlBodyRead = _htmlProcessor.ProcessHtml(pathToFile, replacements);
            await _emailSender.SendEmailAsync(userInvited.Email, "Please verify email", htmlBodyRead);
            return encodedToken.ToString();
        }

        private static void CompleteRegistration(RegisterAppUserCommand request, AppUser? userInvited, string passwordHashed)
        {
            userInvited.Email = request.Email;
            userInvited.Name = request.Name;
            userInvited.LastName = request.LastName;
            userInvited.Shift = request.Shift;
            userInvited.PasswordHash = passwordHashed;
        }

        private static string HashPassword(RegisterAppUserCommand request, AppUser? userInvited)
        {
            var password = new PasswordHasher<AppUser>();
            var hashed = password.HashPassword(userInvited, request.Password);
            return hashed;
        }
    }
}
