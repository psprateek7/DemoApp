using System;
using System.Threading.Tasks;
using demoApp.Interfaces.VMServices;
using demoApp.Interfaces.WebService;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;

namespace demoApp.Services.VMServices
{
    public class LoginService : ILoginService
    {
        private IWebServiceClient webServiceClient { get; set; }

        public LoginService(IWebServiceClient _webServiceClient)
        {
            webServiceClient = _webServiceClient;
        }

        public async Task<LoginResponse> PerformLogin(string uri, LoginReqModel requestModel)
        {
            return await webServiceClient.PostAsync<LoginResponse, LoginReqModel>(uri, requestModel);
        }
    }
}
