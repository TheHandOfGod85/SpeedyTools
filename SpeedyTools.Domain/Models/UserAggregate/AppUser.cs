
using Microsoft.AspNetCore.Identity;

namespace SpeedyTools.Domain.Models.UserAggregate
{
    public class AppUser : IdentityUser
    {
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Shift { get;  set; }
    }
}
