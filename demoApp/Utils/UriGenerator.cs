using System;
using System.Collections.Generic;

namespace demoApp.Utils
{
    public static class UriGenerator
    {
        public static string GenerateQuerryParams(string endpoint, Dictionary<string, object> parameters = null)
        {
            string paramString = string.Empty;

            if (parameters != null)
            {

                foreach (var param in parameters)
                    paramString += $"{param.Key}={param.Value}&";
                paramString = paramString.TrimEnd('&');
            }

            if (!string.IsNullOrEmpty(paramString))
                endpoint += "?" + paramString;

            return endpoint;
        }
    }
}
