using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace demoApp.Models.ResponseModels
{

    public class BaseErrorResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        [JsonProperty(PropertyName = "")]
        public List<string> ErrorList { get; set; }
    }



}
