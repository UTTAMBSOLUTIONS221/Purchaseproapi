using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBL.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public StaffManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }

        #region System Roles
        [HttpGet("Getsystemroles")]
        public async Task<IEnumerable<SystemUserRoles>> Getsystemroles()
        {
            return await bl.GetSystemRoles();
        }
        [HttpPost("Registersystemstaffrole")]
        public async Task<Genericmodel> RegisterSystemStaffRole(Systemuserroledetail obj)
        {
            return await bl.RegisterSystemStaffRole(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemroledetaildata/{RoleId}")]
        public async Task<Systemuserroledetail> GetSystemRoleDetailData(long RoleId)
        {
            return await bl.GetSystemRoleDetailData(RoleId);
        }
        #endregion

        #region System Staffs
        [HttpGet("Getsystemstaffsdata/{TenantId}")]
        public async Task<IEnumerable<SystemStaffModel>> Getsystemstaffsdata(long TenantId)
        {
            return await bl.Getsystemstaffsdata(TenantId);
        }
        [HttpPost("Registersystemtaff")]
        public async Task<Genericmodel> Registersystemtaff(Systemstaffs obj)
        {
            return await bl.Registersystemtaff(obj);
        }
        [HttpGet("Getsystemstaffdatabyid/{StaffId}")]
        public async Task<Systemstaffs> Getsystemstaffdatabyid(long StaffId)
        {
            return await bl.Getsystemstaffdatabyid(StaffId);
        }
        #endregion
    }
}
