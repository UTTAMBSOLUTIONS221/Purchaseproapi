using Newtonsoft.Json;

namespace DBL.Mpesamodels
{
    public class PesaAppRequestData
    {
        [JsonProperty("timestamp")]
        public string? TimeStamp { get; set; }

        [JsonProperty("servicecode")]
        public int ServiceCode { get; set; }

        [JsonProperty("accountnumber")]
        public string? AccountNumber { get; set; }

        [JsonProperty("data")]
        public PesaAppRequestBody? Data { get; set; }
    }
    public class PesaAppRequestBody
    {
        [JsonProperty("accounttopupid")]
        public long AccountTopupId { get; set; }
        [JsonProperty("financetransactionid")]
        public long FinanceTransactionId { get; set; }
        [JsonProperty("accountid")]
        public long AccountId { get; set; }
        [JsonProperty("accountnumber")]
        public long AccountNumber { get; set; }
        [JsonProperty("loandetailid")]
        public long LoanDetailId { get; set; }
        [JsonProperty("loandetailitemid")]
        public long Loandetailitemid { get; set; }
        [JsonProperty("phonenumber")]
        public string? Phonenumber { get; set; }
        [JsonProperty("paymentamount")]
        public decimal Paymentamount { get; set; }
        [JsonProperty("recievedamount")]
        public decimal Recievedamount { get; set; }
        [JsonProperty("modeofpayment")]
        public string? ModeofPayment { get; set; }
        [JsonProperty("paymentmemo")]
        public string? Paymentmemo { get; set; }
        [JsonProperty("topupreference")]
        public string? Topupreference { get; set; }
        [JsonProperty("createdby")]
        public long Createdby { get; set; }
        [JsonProperty("datecreated")]
        public DateTime DateCreated { get; set; }
    }

    public class PaymentRecord
    {
        [JsonProperty("accno")]
        public string? AccountNo { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("refno")]
        public string? RefNo { get; set; }

        [JsonProperty("accref")]
        public string? AccountRef { get; set; }
    }
}
