namespace DBL.Models
{
    public class SystemUserRoles
    {
        public long RoleId { get; set; }
        public string? Rolename { get; set; }
        public string? Roledescription { get; set; }
        public bool IsDefault { get; set; }
    }
}
