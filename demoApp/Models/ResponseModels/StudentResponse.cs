using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace demoApp.Models.ResponseModels
{
    public class StudentResponse : GenericResponse
    {
        [JsonProperty(PropertyName = "students")]
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
    }
}
