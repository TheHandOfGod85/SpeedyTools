using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Contracts.AppUserS.Responses
{
    public class AppUserDto 
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }
}
