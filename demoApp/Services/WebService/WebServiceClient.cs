using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using demoApp.AppHelpers;
using demoApp.Interfaces.WebService;
using demoApp.Utils;
using Newtonsoft.Json;

namespace demoApp.Services.WebService
{
    public class WebServiceClient : IWebServiceClient
    {
        public HttpClient client { get; set; }
        private void InitDefaultHeaders(HttpClient httpClient, bool isTokenRequired)
        {
            string content_type = "application/json";
            httpClient.DefaultRequestHeaders.Add("Accept", content_type);

            if (isTokenRequired)
            {
                var token = AppSession.GetSessionParam(AppConstants.SessionParams.Token);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }


        public async Task<T> GetAsync<T>(string uri, bool isTokenRequired = true)
        {
            string response = string.Empty;
            var httpResponse = new HttpResponseMessage();

            using (HttpClient client = SetHttpClientObject())
            {
                InitDefaultHeaders(client, isTokenRequired);
                httpResponse = await client.GetAsync(uri);
                ValidateResponseStatus(httpResponse);
                response = await httpResponse.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(response);
        }

        private HttpClient SetHttpClientObject()
        {
            if (client == null)
                return new HttpClient();
            return client;
        }

        public async Task<T> PostAsync<T, U>(string uri, U _requestContent, bool isTokenRequired = true)
        {
            string response = string.Empty;
            var httpResponse = new HttpResponseMessage();

            using (HttpClient client = new HttpClient())
            {
                var reqJson = JsonConvert.SerializeObject(_requestContent);
                InitDefaultHeaders(client, isTokenRequired);
                var content = new StringContent(reqJson, Encoding.UTF8, "application/json");
                httpResponse = await client.PostAsync(uri, content);
                ValidateResponseStatus(httpResponse);
                response = await httpResponse.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Validates the web response status.
        /// </summary>
        /// <param name="response">http response recieved from the api call</param>       
        private void ValidateResponseStatus(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new Exception(AppConstants.ErrorCodes.InternalServerError);
            }
            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.BadRequest)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        throw new Exception(AppConstants.ErrorCodes.AccessDenied);

                    case HttpStatusCode.NotFound:
                        throw new Exception(AppConstants.ErrorCodes.NotFound);

                    case HttpStatusCode.Unauthorized:
                        throw new Exception(AppConstants.ErrorCodes.AccessDenied);

                    case HttpStatusCode.Gone:
                        throw new Exception(AppConstants.ErrorCodes.InternalServerError);

                    default:
                        throw new Exception(AppConstants.ErrorCodes.InternalServerError);
                }

            }

        }
    }
}
