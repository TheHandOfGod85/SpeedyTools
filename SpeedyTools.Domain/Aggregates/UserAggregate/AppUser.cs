
namespace SpeedyTools.Domain.Aggregates.UserAggregate
{
    public class AppUser
    {
        public Guid AppUserId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Shift { get; private set; }
        public Roles Role { get; private set; }
    }
}
