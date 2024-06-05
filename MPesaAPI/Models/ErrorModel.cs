using Newtonsoft.Json;

namespace MPesaAPI.Models
{
    public class ErrorModel
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
