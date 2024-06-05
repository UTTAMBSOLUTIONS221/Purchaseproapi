namespace DBL.Models
{
    public class Systemcustomerdetaildatamodel
    {
        public long CustomerId { get; set; }
        public long TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string? CustomerEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CustomerStatus { get; set; }
        public string? IdNumber { get; set; }
        public string? Krapin { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Gender { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Systemcustomerasset>? Systemcustomerassets { get; set; }
        public List<Customerloanitem>? Customerloanitems { get; set; }
        public List<LoanPaymentModel>? Customerloanpayments { get; set; }
    }

    public class Systemcustomerasset
    {
        public long LoanDetailId { get; set; }
        public long AssetDetailId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LoanPeriod { get; set; }
        public string? PaymentTerm { get; set; }
        public DateTime StartDate { get; set; }
        public int LoanStatus { get; set; }
        public long CustomerId { get; set; }
        public long AssetId { get; set; }
        public string? AssetNameType { get; set; }
        public string? AssetName { get; set; }
        public string? AssetNumber { get; set; }
        public long AssetMakeId { get; set; }
        public string? VehicleMakeName { get; set; }
        public long AssetModelId { get; set; }
        public string? VehicleModelName { get; set; }
        public string? AssetChaseNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal TankCapacity { get; set; }
        public decimal OdometerReading { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class Customerloanitem
    {
        public long LoanDetailItemId { get; set; }
        public long LoanDetailId { get; set; }
        public string? AssetNumber { get; set; }
        public string? AssetName { get; set; }
        public long AccountNumber { get; set; }
        public long AccountId { get; set; }
        public long CustomerId { get; set; }
        public int Period { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Outstandingbalance { get; set; }
        public int PaymentStatus { get; set; }
        public string? PaymentReason { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
    }
    public class LoanPaymentModel
    {
        public long AccountTopupId { get; set; }
        public long FinanceTransactionId { get; set; }
        public long AccountId { get; set; }
        public long Loandetailitemid { get; set; }
        public decimal Paymentamount { get; set; }
        public decimal Recievedamount { get; set; }
        public string? ModeofPayment { get; set; }
        public string? Paymentmemo { get; set; }
        public string? Topupreference { get; set; }
        public string? CreatedByName { get; set; }
        public string? TransactionCode { get; set; }
        public string? Topupreferencecode { get; set; }
        public long ParentId { get; set; }
        public string? Saledescription { get; set; }
        public string? SaleReference { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
