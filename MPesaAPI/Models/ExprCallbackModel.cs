using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPesaAPI.Models
{
    public class ExprCallbackModel
    {
        [JsonProperty("Body")]
        public ExprCallbackBody CallbackBody { get; set; }
    }

    public class ExprCallbackBody
    {
        [JsonProperty("stkCallback")]
        public ExprCallbackContent CallbackContent { get; set; }
    }

    public class ExprCallbackContent
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }

        [JsonProperty("CallbackMetadata")]
        public ExprCallbackData CallbackData { get; set; }
    }

    public class ExprCallbackData
    {
        [JsonProperty("Item")]
        public ExprCallbackDataItem[] CallbackValues { get; set; }
    }

    public class ExprCallbackDataItem
    {
        [JsonProperty("Name")]
        public string ItemName { get; set; }

        [JsonProperty("Value")]
        public string ItemValue { get; set; }
    }
}
