using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPesaAPI.Models
{
    public class RegisterC2BUrlResponseData
    {
        [JsonProperty("OriginatorCoversationID")]
        public string? OriginatorCoversationID { get; set; }

        [JsonProperty("ResponseCode")]
        public string? ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string? ResponseDescription { get; set; }
    }
}
