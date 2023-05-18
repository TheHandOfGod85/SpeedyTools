using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class ResendConfirmationEmailCommand : IRequest<string>
    {
        public ResendConfirmationEmailCommand(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }

    public class ResendConfirmationEmailCommandHandler : IRequestHandler<ResendConfirmationEmailCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailSender;
        private readonly IEncoderService _encoderService;
        private readonly IApiContextAccessor _contextAccessor;
        private readonly IWebRootPathBuilder _rootPathBuilder;
        private readonly IHtmlProcessor _htmlProcessor;

        public ResendConfirmationEmailCommandHandler
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

        public async Task<string> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null) { return null; }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            _encoderService.Encode(token);
            var origin = _contextAccessor.GetOrigin();
            var verifyUrl = $"{origin}/user/verifyEmail?token={token}&email={appUser.UserName}";
            var pathToFile = _rootPathBuilder.GetWebRootPath("Templates", "EmailConfirmationTemplate.html");
            string htmlBodyRead = _htmlProcessor.ProcessHtml(pathToFile);
            htmlBodyRead = htmlBodyRead.Replace("{0}", request.Email);
            htmlBodyRead = htmlBodyRead.Replace("{1}", verifyUrl);
            htmlBodyRead = htmlBodyRead.Replace("{2}", verifyUrl);
            await _emailSender.SendEmailAsync(appUser.UserName, "Please verify email", htmlBodyRead);
            return "Email verification link resent";
        }
    }
}
