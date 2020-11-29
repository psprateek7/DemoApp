using System;
using System.Threading.Tasks;

namespace demoApp.Interfaces.WebService
{
    public interface IWebServiceClient
    {
        /// <summary>
        /// Use this to process HTTP GET verb.
        /// </summary>
        /// <typeparam name="T">returns the type "T" deserialised response</typeparam>
        /// <param name="uri">URI to process</param>
        /// <returns>returns the object</returns>
        Task<T> GetAsync<T>(string uri, bool isTokenRequired = true);

        /// <summary>
        ///  Use this to process HTTP POST verb.
        /// </summary>
        /// <typeparam name="T">Class for deserialising the response content.</typeparam>
        /// <typeparam name="U">Generic U type request model.</typeparam>
        /// <param name="uri">URI to process</param>
        /// <param name="requestContent">request model</param>
        /// <returns>Returns deserialised type T response</returns>
        Task<T> PostAsync<T, U>(string uri, U requestContent, bool isTokenRequired = true);
    }
}
