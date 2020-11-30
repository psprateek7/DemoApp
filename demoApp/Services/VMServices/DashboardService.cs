using System;
using System.Threading.Tasks;
using demoApp.DBHelper;
using demoApp.DBHelper.Utils;
using demoApp.Interfaces.VMServices;
using demoApp.Interfaces.WebService;
using demoApp.Models.ResponseModels;

namespace demoApp.Services.VMServices
{
    public class DashboardService : BaseService, IDashboardService
    {
        private readonly ISqliteHelper sqliteHelper;

        public DashboardService(IWebServiceClient _webServiceClient, ISqliteHelper _sqliteHelper) : base(_webServiceClient)
        {
            sqliteHelper = _sqliteHelper;
        }

        public async Task<StudentResponse> GetListOfStudents(string uri)
        {
            return await webServiceClient.GetAsync<StudentResponse>(uri);
        }

        public async Task<bool> AddDetailsToDB(StudentResponse students)
        {
            bool isSyncSuccessful = false;
            foreach (var student in students.Students)
            {
                var studentEntity = new Student();
                studentEntity.FirstName = student.FirstName;
                studentEntity.LastName = student.LastName;
                studentEntity.Age = student.Age;
                studentEntity.Email = student.Email;
                studentEntity.PhoneNumber = student.PhoneNumber;
                student.ID = student.ID;

                var isInitialised = await sqliteHelper.InitializeAsync(SqliteHelperConstants.StudentEntityName);

                if (isInitialised)
                {
                    isSyncSuccessful = await sqliteHelper.SaveItemAsync<Student>(studentEntity);
                }
                else
                {
                    isSyncSuccessful = false;
                }
            }

            return isSyncSuccessful;


        }
    }
}
