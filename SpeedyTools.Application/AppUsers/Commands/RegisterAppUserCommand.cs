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
            if (_userManager.Users.Any(x => x.Email == request.UserName))
            {
                return null;
            }
            AppUser appUser = CreateUser(request);
            var result = await _userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded) { throw new Exception(message: $"{result.Errors.FirstOrDefault().Description}"); }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var encodedToken =_encoderService.Encode(token);
            var origin = _contextAccessor.GetOrigin();
            var verifyUrl = $"{origin}/user/verifyEmail?token={encodedToken}&email={appUser.UserName}";
            var pathToFile = _rootPathBuilder.GetWebRootPath("Templates", "EmailConfirmationTemplate.html");
            List<string> replacements = new List<string> { request.UserName, verifyUrl, verifyUrl };
            string htmlBodyRead = _htmlProcessor.ProcessHtml(pathToFile, replacements);
            await _emailSender.SendEmailAsync(appUser.UserName, "Please verify email", htmlBodyRead);
            return encodedToken.ToString();
        }

        private static AppUser CreateUser(RegisterAppUserCommand request)
        {
            return new AppUser
            {
                Email = request.UserName,
                UserName = request.UserName,
                Name = request.Name,
                LastName = request.LastName,
                Shift = request.Shift,
            };
        }
    }
}
