namespace DBL.Entities
{
    public class Customerloandetailsdata
    {
        public long Assetdetailid { get; set; }
        public long Customerid { get; set; }
        public long Assetid { get; set; }
        public string? Assetname { get; set; }
        public string? Assetnumber { get; set; }
        public long Assetmakeid { get; set; }
        public long Assetmodelid { get; set; }
        public string? Assetchasenumber { get; set; }
        public int Yearofmanufacture { get; set; }
        public decimal Tankcapacity { get; set; }
        public decimal Odometerreading { get; set; }
        public decimal Loanamount { get; set; }
        public decimal Paidamount { get; set; }
        public decimal Interestrate { get; set; }
        public decimal Loanperiod { get; set; }
        public string? Paymentterm { get; set; }
        public DateTime Startdate { get; set; }
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
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }

    }
}
