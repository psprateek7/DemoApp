using System;
using Xamarin.Essentials;

namespace demoApp.AppHelpers
{
    public class AppSession
    {
        ///// <summary>
        ///// Initialize the Keys with default values
        ///// </summary>
        //public static void Initialize()
        //{
        //    try
        //    {
        //        Preferences.Set(SessionParamNames.Email, string.Empty);
        //        Preferences.Set(SessionParamNames.MobileNumber, string.Empty);
        //        Preferences.Set(SessionParamNames.GuestID, string.Empty);
        //        Preferences.Set(SessionParamNames.ApplicationRunningForFirstTime, "true");
        //        Preferences.Set(SessionParamNames.ApplicationLanguage, "en");
        //        Preferences.Set(SessionParamNames.AccessToken, string.Empty);
        //        Preferences.Set(SessionParamNames.UserId, string.Empty);
        //        Preferences.Set(SessionParamNames.HasAcceptedPP, "false");
        //        Preferences.Set(SessionParamNames.IsVerified, "false");
        //        Preferences.Set(SessionParamNames.hCO, string.Empty);
        //        Preferences.Set(SessionParamNames.PNSToken, string.Empty);
        //        Preferences.Set(SessionParamNames.NotificationCount, string.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Retrieves session details
        ///// </summary>
        ///// <returns>returns session param object</returns>
        //public static SessionParam GetSessionDetails()
        //{
        //    try
        //    {
        //        var objParam = new SessionParam();
        //        {
        //            objParam.Email = Preferences.Get(SessionParamNames.Email, string.Empty);
        //            objParam.MobileNumber = Preferences.Get(SessionParamNames.MobileNumber, string.Empty);
        //            objParam.GuestID = Preferences.Get(SessionParamNames.GuestID, string.Empty);
        //            objParam.ApplicationRunningForFirstTime = Preferences.Get(SessionParamNames.ApplicationRunningForFirstTime, "true");
        //            objParam.ApplicationLanguage = Preferences.Get(SessionParamNames.ApplicationLanguage, "en");
        //            objParam.AccessToken = Preferences.Get(SessionParamNames.AccessToken, string.Empty);
        //            objParam.UserId = Preferences.Get(SessionParamNames.UserId, string.Empty);
        //            objParam.HasAcceptedPP = Preferences.Get(SessionParamNames.HasAcceptedPP, "false");
        //            objParam.IsVerified = Preferences.Get(SessionParamNames.IsVerified, "false");
        //            objParam.hCO = Preferences.Get(SessionParamNames.hCO, string.Empty);
        //            objParam.Username = Preferences.Get(SessionParamNames.Username, string.Empty);
        //            objParam.PNSToken = Preferences.Get(SessionParamNames.PNSToken, string.Empty);
        //            objParam.NotificationCount = Preferences.Get(SessionParamNames.NotificationCount, string.Empty);

        //        }
        //        return objParam;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new SessionParam
        //        {
        //            AccessToken = string.Empty,
        //            ApplicationRunningForFirstTime = "true"
        //        };
        //    }
        //}

        /// <summary>
        /// Get a Specific SessionParamValue
        /// </summary>
        /// <param name="key">key is a string parameter to get a Specific SessionParamValue</param>
        /// <returns>returns string</returns>
        public static string GetSessionParam(string key)
        {
            return Preferences.Get(key, string.Empty);
        }

        /// <summary>
        /// Update Session Param with the key and value provided
        /// </summary>
        /// <param name="key">key is a string parameter to update Session Param</param>
        /// <param name="value">value is a string parameter to update Session Param</param>
        public static void UpdateSessionParam(string key, string value)
        {
            Preferences.Set(key, value);
        }

        ///// <summary>
        ///// Deletes all the stored Session parameters
        ///// </summary>
        //public static void LogOut()
        //{
        //    UpdateSessionParam(SessionParamNames.Email, string.Empty);
        //    UpdateSessionParam(SessionParamNames.MobileNumber, string.Empty);
        //    UpdateSessionParam(SessionParamNames.GuestID, string.Empty);
        //    UpdateSessionParam(SessionParamNames.AccessToken, string.Empty);
        //    UpdateSessionParam(SessionParamNames.UserId, string.Empty);
        //    UpdateSessionParam(SessionParamNames.HasAcceptedPP, "false");
        //    UpdateSessionParam(SessionParamNames.IsVerified, "false");
        //    UpdateSessionParam(SessionParamNames.hCO, string.Empty);
        //    UpdateSessionParam(SessionParamNames.Username, string.Empty);
        //    UpdateSessionParam(SessionParamNames.SearchHistory, string.Empty);
        //    UpdateSessionParam(SessionParamNames.NotificationCount, string.Empty);
        //}


        /// <summary>
        /// Object for Session Parameters
        /// </summary>
        //public sealed class SessionParam
        //{
        //    public string Username { get; set; }
        //    public string hCO { get; set; }
        //    public string HasAcceptedPP { get; set; }
        //    public string IsVerified { get; set; }
        //    public string Email { get; set; }
        //    public string MobileNumber { get; set; }
        //    public string GuestID { get; set; }
        //    public string ApplicationRunningForFirstTime { get; set; }
        //    public string ApplicationLanguage { get; set; }
        //    public string AccessToken { get; set; }
        //    public string UserId { get; set; }
        //    public string SearchHistory { get; set; }
        //    public string PNSToken { get; set; }
        //    public string NotificationCount { get; set; }
        //    public bool IsGuest => string.IsNullOrEmpty(Email);

        //    /// <summary>
        //    /// Constrcutor used to initialize default values
        //    /// </summary>
        //    public SessionParam()
        //    {
        //        Email = string.Empty;
        //        Username = string.Empty;
        //        MobileNumber = string.Empty;
        //        GuestID = string.Empty;
        //        ApplicationRunningForFirstTime = "true";
        //        HasAcceptedPP = "false";
        //        IsVerified = "false";
        //        hCO = string.Empty;
        //        ApplicationLanguage = "en";
        //        AccessToken = string.Empty;
        //        UserId = string.Empty;
        //        PNSToken = string.Empty;
        //        SearchHistory = string.Empty;
        //        NotificationCount = string.Empty;
        //    }
        //}
    }
}

