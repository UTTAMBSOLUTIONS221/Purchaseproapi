using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ISecurityRepository
    {
        UsermodelResponce VerifySystemStaff(string Username);
        IEnumerable<SystemStaffModel> Getsystemstaffsdata(long TenantId);
        Genericmodel Registersystemtaff(string JsonEntity);
        Systemstaffs Getsystemstaffdatabyid(long StaffId);
        Genericmodel Resetuserpasswordpost(string JsonObjectdata);
        Genericmodel Registersystemcustomeruserdata(string JsonEntity);
        IEnumerable<SystemUserRoles> GetSystemRoles();
        Genericmodel RegisterSystemStaffRole(string JsonEntity);
        Systemuserroledetail GetSystemRoleDetailData(long RoleId);

    }
}
