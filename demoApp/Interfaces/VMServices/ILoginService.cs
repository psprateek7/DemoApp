using System;
using System.Threading.Tasks;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;

namespace demoApp.Interfaces.VMServices
{
    public interface ILoginService
    {

        Task<LoginResponse> PerformLogin(string uri, LoginReqModel requestModel);
    }
}
