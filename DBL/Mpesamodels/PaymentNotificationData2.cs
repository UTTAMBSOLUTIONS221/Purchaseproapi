using Newtonsoft.Json;

namespace DBL.Mpesamodels
{
    public class PaymentNotificationData2
    {
        [JsonProperty("tsp")]
        public string TimeStamp { get; set; }

        [JsonProperty("stat")]
        public int Status { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("sref")]
        public string SourceRef { get; set; }

        [JsonProperty("txn")]
        public PaymentTransaction Transaction { get; set; }
    }

    public class PaymentTransaction
    {
        [JsonProperty("amnt")]
        public decimal Amount { get; set; }

        [JsonProperty("refno")]
        public string ReferenceNo { get; set; }

        [JsonProperty("accno")]
        public string PayAccountNo { get; set; }

        [JsonProperty("custno")]
        public string CustomerNo { get; set; }

        [JsonProperty("custname")]
        public string CustomerName { get; set; }

        [JsonProperty("bal")]
        public decimal AccountBalance { get; set; }

        [JsonProperty("init_ref")]
        public string InitialRef { get; set; }
    }
}