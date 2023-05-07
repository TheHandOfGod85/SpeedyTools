
namespace SpeedyTools.Domain.Aggregates.UserAggregate
{
    public class AppUser
    {
        private AppUser()
        {
            
        }
        public Guid AppUserId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Shift { get; private set; }
        public Roles Role { get; private set; }


        public static AppUser CreateAppUser(string name, string lastName, string shift, Roles role)
        {
            var appUser = new AppUser
            {
                Name = name,
                LastName = lastName,
                Shift = shift,
                Role = role
            };
            return appUser;
        }
    }
}
