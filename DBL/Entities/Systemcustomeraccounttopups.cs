namespace DBL.Entities
{
    public class Systemcustomeraccounttopups
    {
        public long AccountTopupId { get; set; }
        public long FinanceTransactionId { get; set; }
        public long AccountId { get; set; }
        public long AccountNumber { get; set; }
        public long LoanDetailId { get; set; }
        public long Loandetailitemid { get; set; }
        public string? Phonenumber { get; set; }
        public decimal Paymentamount { get; set; }
        public decimal Recievedamount { get; set; }
        public string? ModeofPayment { get; set; }
        public string? Paymentmemo { get; set; }
        public string? Topupreference { get; set; }
        public long Createdby { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
