using System;
namespace demoApp.Utils
{
    public static class AppConstants
    {
        public static class ErrorCodes
        {
            public const string AccessDenied = "Access Denied.";
            public const string NotFound = "Not Found.";
            public const string InternalServerError = "Unable to contact server.";
        }

        public static class SessionParams
        {
            public const string Token = "Token";
        }

        public static class EndPoints
        {

#if DEBUG
            public static readonly string HostUri = "https://developer.fusionstak.com/demoapp/api";
#endif
#if RELEASE
            public static readonly string HostUri = "https://developer.fusionstak.com/demoapp/api";
#endif

            public static readonly string Login = $"{EndPoints.HostUri}/account/token";

            public static readonly string AddUser = $"{EndPoints.HostUri}/user/add";

            public static readonly string GetUsers = $"{EndPoints.HostUri}/user";
        }

        public static class MessagingCenterConsts
        {

            public const string NetworkChanged = "NetworkChanged";
        }



    }
}
