namespace SpeedyTools.Application.Contracts.AppUserS.Responses
{
    public class AppUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
        public List<string> Roles { get; set; }
    }
}
