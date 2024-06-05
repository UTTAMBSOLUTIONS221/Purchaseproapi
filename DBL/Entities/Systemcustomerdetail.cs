namespace DBL.Entities
{
    public class Systemcustomerdetail
    {
        public long Customerid { get; set; }
        public long Tenantid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Imageurl { get; set; }
        public string? Customeremail { get; set; }
        public string? Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public string? Customerstatus { get; set; }
        public string? Passwords { get; set; }
        public string? Passwordharsh { get; set; }
        public string? Idnumber { get; set; }
        public string? Krapin { get; set; }
        public string? Licensenumber { get; set; }
        public int Gender { get; set; }
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
