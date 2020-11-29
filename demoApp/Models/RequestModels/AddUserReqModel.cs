using System;
namespace demoApp.Models.RequestModels
{
    public class AddUserReqModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
