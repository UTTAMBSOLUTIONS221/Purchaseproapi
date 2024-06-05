namespace DBL.Models
{
    public class Systemreportdataandparameters
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public long customerid { get; set; }
        public long assetdetailid { get; set; }
        public long loanstatus { get; set; }
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Customername { get; set; }
        public string? Assetdetailname { get; set; }
        public string? Loanstatusname { get; set; }
        public IEnumerable<Systemloanrepaymentmodel>? Loanrepaymentreportdata { get; set; }
    }
    public class Systemloanrepaymentmodel
    {
        public string? AssetNumber { get; set; }
        public string? AssetName { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public int Period { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal WeeklyOutstandingBalance { get; set; }
        public decimal CumulativeOutstandingBalance { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentReason { get; set; }
    }

}
