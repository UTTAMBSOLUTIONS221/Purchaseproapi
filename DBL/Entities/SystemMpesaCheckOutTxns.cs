namespace DBL.Entities
{
    public class SystemMpesaCheckOutTxns
    {
        public bool IsTxnSuccessFull { get; set; }
        public DateTime datecreated { get; set; }
        public string? transId { get; set; }
        public decimal transAmount { get; set; }
        public string? transactionType { get; set; }
        public string? invoiceNumber { get; set; }
        public string? firstName { get; set; }
    }
}
