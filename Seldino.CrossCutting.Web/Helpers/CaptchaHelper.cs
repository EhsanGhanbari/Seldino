using System.Collections.Generic;
using Newtonsoft.Json;

namespace Seldino.CrossCutting.Web.Helpers
{

    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
