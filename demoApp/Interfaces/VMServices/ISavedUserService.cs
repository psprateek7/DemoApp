using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demoApp.DBHelper.Entities;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;

namespace demoApp.Interfaces.VMServices
{
    public interface ISavedUserService
    {
        Task<List<User>> GetSavedUser();

        Task<GenericResponse> SubmitUserDetails(string uri, AddUserReqModel requestModel);

        Task<bool> DeleteItemIfSynced(User user);
    }
}
