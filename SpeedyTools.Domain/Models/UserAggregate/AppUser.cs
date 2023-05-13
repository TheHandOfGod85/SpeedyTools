

namespace SpeedyTools.Domain.Models.UserAggregate
{
    public class AppUser 
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Shift { get;  set; }
    }
}
