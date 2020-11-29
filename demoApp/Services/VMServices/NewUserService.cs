using System;
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
    public class NewUserService : BaseService, INewUserService
    {
        private readonly ISqliteHelper sqliteHelper;

        public NewUserService(IWebServiceClient _webServiceClient, ISqliteHelper _sqliteHelper) : base(_webServiceClient)
        {
            sqliteHelper = _sqliteHelper;
        }

        public async Task<GenericResponse> SubmitUserDetails(string uri, AddUserReqModel requestModel)
        {
            return await webServiceClient.PostAsync<GenericResponse, AddUserReqModel>(uri, requestModel);
        }

        public async Task<bool> AddDetailsToDB(AddUserReqModel requestModel)
        {
            var userEntity = new User();
            userEntity.FirstName = requestModel.FirstName;
            userEntity.LastName = requestModel.LastName;
            userEntity.Age = requestModel.Age;
            userEntity.Email = requestModel.Email;
            userEntity.PhoneNumber = requestModel.PhoneNumber;

            var isInitialised = await sqliteHelper.InitializeAsync(SqliteHelperConstants.UserEntityName);

            if (isInitialised)
            {
                return await sqliteHelper.SaveItemAsync<User>(userEntity);
            }
            return false;

        }
    }
}
