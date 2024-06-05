using DBL;
using DBL.Entities;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Purchaseproapi.Models;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public AccountManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }
        [AllowAnonymous]
        [Route("Authenticate"), HttpPost]
        public async Task<UsermodelResponce> AuthenticateAsync([FromBody] Usercred userdata)
        {
            return await bl.ValidateSystemStaff(userdata.username, userdata.password);
        }
        [HttpPost("Resendstaffpassword/{StaffId}")]
        public async Task<Genericmodel> Resendstaffpassword(long StaffId)
        {
            return await bl.Resendstaffpassword(StaffId);
        }

        [HttpPost("Resetuserpasswordpost")]
        [AllowAnonymous]
        public async Task<Genericmodel> Resetuserpasswordpost(Staffresetpassword obj)
        {
            return await bl.Resetuserpasswordpost(obj);
        }


    }
}
