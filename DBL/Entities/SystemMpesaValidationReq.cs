namespace DBL.Entities
{
    public class SystemMpesaValidationReq
    {
        public string? TransactionType { get; set; }
        public string? TransID { get; set; }
        public string? TransTime { get; set; }
        public string? TransAmount { get; set; }
        public string? BusinessShortCode { get; set; }
        //accountNumber customer is making the payment, applicable for customer PayBill Transactions
        public string? BillRefNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? OrgAccountBalance { get; set; }
        public string? ThirdPartyTransID { get; set; }
        public string? MSISDN { get; set; }
        public string? FirstName { get; set; }
    }
}
