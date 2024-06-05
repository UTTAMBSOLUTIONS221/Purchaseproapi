using MPesaAPI.Enums;
using Newtonsoft.Json;

namespace MPesaAPI.Models
{
    public class RequestResponse
    {
        public ResponseStatus Status { get; set; }
        public string? StatusNo { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
