using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demoApp.DBHelper;
using demoApp.DBHelper.Entities;
using demoApp.DBHelper.Utils;
using demoApp.Interfaces.VMServices;
using demoApp.Interfaces.WebService;
using demoApp.Models.RequestModels;
using demoApp.Models.ResponseModels;

namespace demoApp.Services.VMServices
{
    public class SavedUserService : BaseService, ISavedUserService
    {
        private readonly ISqliteHelper sqliteHelper;

        public SavedUserService(IWebServiceClient _webServiceClient, ISqliteHelper _sqliteHelper) : base(_webServiceClient)
        {
            sqliteHelper = _sqliteHelper;

        }

        public async Task<GenericResponse> SubmitUserDetails(string uri, AddUserReqModel requestModel)
        {
            return await webServiceClient.PostAsync<GenericResponse, AddUserReqModel>(uri, requestModel);
        }

        public async Task<List<User>> GetSavedUser()
        {
            List<User> unSyncedUsers;

            var isInitialised = await sqliteHelper.InitializeAsync(SqliteHelperConstants.UserEntityName);

            if (isInitialised)
            {
                unSyncedUsers = (List<User>)await sqliteHelper.GetItemsAsync<User>();
            }
            else
            {
                unSyncedUsers = new List<User>();
            }

            return unSyncedUsers;
        }

        public async Task<bool> DeleteItemIfSynced(User user)
        {
            return await sqliteHelper.DeleteItemAsync<User>(user);
        }
    }
}
