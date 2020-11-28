using System;
using Newtonsoft.Json;

namespace demoApp.Models.ResponseModels
{
    public class LoginResponse : BaseErrorResponse
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "tokenResult")]
        public TokenResult TokenResult { get; set; }

        [JsonProperty(PropertyName = "twoFactorRequired")]
        public bool TwoFactorRequired { get; set; }

        [JsonProperty(PropertyName = "refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class TokenResult
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public DateTime Expiration { get; set; }
    }


}
