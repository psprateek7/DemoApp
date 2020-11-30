using System;
using System.Threading.Tasks;
using demoApp.Models.ResponseModels;

namespace demoApp.Interfaces.VMServices
{
    public interface IDashboardService
    {
        Task<StudentResponse> GetListOfStudents(string uri);

        Task<bool> AddDetailsToDB(StudentResponse students);
    }
}
