using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPesaAPI.Models
{
    public class C2BValidationResp
    {
        [JsonProperty("ResultCode")]
        public int ResultCode { get; set; }

        [JsonProperty("ResultDesc")]
        public string ResultDesc { get; set; }

        [JsonProperty("ThirdPartyTransID")]
        public string ThirdPartyTransID { get; set; }
    }
}
