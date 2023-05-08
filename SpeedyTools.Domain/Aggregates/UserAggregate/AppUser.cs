
namespace SpeedyTools.Domain.Aggregates.UserAggregate
{
    public class AppUser
    {
        public Guid AppUserId { get;  set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Shift { get;  set; }
        public Roles Role { get;  set; }
    }
}
