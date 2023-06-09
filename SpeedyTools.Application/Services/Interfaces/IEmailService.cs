﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}
