using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SpeedyTools.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Implementations
{
    public class SendGridService : ISendGridService
    {
        private readonly IConfiguration _config;

        public SendGridService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string userEmail, string emailSubject, string message)
        {
            var client = new SendGridClient(_config["SendGrid:Key"]);
            var emailMessage = new SendGridMessage
            {
                From = new EmailAddress("sideprojects85@hotmail.com", _config["Sendgrid:User"]),
                Subject = emailSubject,
                PlainTextContent = message,
                HtmlContent = message
            };
            emailMessage.AddTo(new EmailAddress(userEmail));
            emailMessage.SetClickTracking(false, false);

            await client.SendEmailAsync(emailMessage);
        }
    }
}
