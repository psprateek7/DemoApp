using System;
using System.Threading.Tasks;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;

namespace demoApp.Interfaces.VMServices
{
    public interface INewUserService
    {
        Task<GenericResponse> SubmitUserDetails(string uri, AddUserReqModel requestModel);

        Task<bool> AddDetailsToDB(AddUserReqModel requestModel);
    }
}
