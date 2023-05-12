namespace SpeedyTools.Api
{
    public static class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public static class Identity
        {
            public const string Account = "account";
            public const string Registration = "registration";
            public const string CompleteRegistration = "completeRegistration";
        }
    }
}
