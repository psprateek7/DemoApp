using System;
using demoApp.Interfaces.WebService;

namespace demoApp.Services.VMServices
{
    public class BaseService
    {
        protected IWebServiceClient webServiceClient { get; set; }

        public BaseService(IWebServiceClient _webServiceClient)
        {
            webServiceClient = _webServiceClient;
        }
    }
}
