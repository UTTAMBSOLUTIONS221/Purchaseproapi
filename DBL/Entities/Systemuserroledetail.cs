using DBL.Models;

namespace DBL.Entities
{
    public class Systemuserroledetail
    {
        public long RoleId { get; set; }
        public string? Rolename { get; set; }
        public string? Roledescription { get; set; }
        public bool IsDefault { get; set; }
        public List<SystemPermissions>? Permissions { get; set; }
    }
}
