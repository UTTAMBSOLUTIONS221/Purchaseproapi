namespace DBL.Models
{
    public class SystemStaffModel
    {
        public long Staffid { get; set; }
        public long Tenantid { get; set; }
        public string? Tenantname { get; set; }
        public string? RoleName { get; set; }
        public string? Staffname { get; set; }
        public string? Emailaddress { get; set; }
        public long Roleid { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? Passwords { get; set; }
        public string? Passwordharsh { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDefault { get; set; }
        public bool Isstaff { get; set; }
        public bool Changepassword { get; set; }
        public DateTime Passwordchangedate { get; set; }
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
        public long? ParentId { get; set; }
        public long? LoginStatus { get; set; }
        public long? Createdby { get; set; }
        public long? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
