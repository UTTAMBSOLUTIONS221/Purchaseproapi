using System.Security;

namespace DBL.Models
{
    public class Systemstaffresponse
    {
        public long RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public long StaffId { get; set; }
        public string? Displayname { get; set; }
        public string? Fullname { get; set; }
        public string? Phonenumber { get; set; }
        public string? Emailaddress { get; set; }
        public long Roleid { get; set; }
        public string? Rolename { get; set; }
        public string? Passharsh { get; set; }
        public string? Passwords { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Loginstatus { get; set; }
        public bool Changepassword { get; set; }
        public DateTime Passwordresetdate { get; set; }
        public long ParentId { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public List<SystemPermissions>? Permission { get; set; }
    }
}
