using System;
using Xamarin.Essentials;

namespace demoApp.AppHelpers
{
    public class AppSession
    {


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


    }
}

