using DBL;
using DBL.Entities;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly BL bl;
        public MaintenanceController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
        }

        #region System Permissions
        [HttpGet("Getsystempermissiondata")]
        public async Task<IEnumerable<Systempermissions>> Getsystempermissiondata()
        {
            return await bl.Getsystempermissiondata();
        }

        [HttpPost("Registersystempermissiondata")]
        public async Task<Genericmodel> Registersystempermissiondata(Systempermissions obj)
        {
            return await bl.Registersystempermissiondata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystempermissiondatabyid/{Permissionid}")]
        public async Task<Systempermissions> Getsystempermissiondatabyid(long Permissionid)
        {
            return await bl.Getsystempermissiondatabyid(Permissionid);
        }
        #endregion

        #region System Vehicle Makes
        [HttpGet("Getsystemvehiclemakedata")]
        public async Task<IEnumerable<Systemvehiclemakes>> Getsystemvehiclemakedata()
        {
            return await bl.Getsystemvehiclemakedata();
        }

        [HttpPost("Registersystemvehiclemakedata")]
        public async Task<Genericmodel> Registersystemvehiclemakedata(Systemvehiclemakes obj)
        {
            return await bl.Registersystemvehiclemakedata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemvehiclemakedatabyid/{Vehiclemakeid}")]
        public async Task<Systemvehiclemakes> Getsystemvehiclemakedatabyid(long Vehiclemakeid)
        {
            return await bl.Getsystemvehiclemakedatabyid(Vehiclemakeid);
        }
        #endregion

        #region System Vehicle Models
        [HttpGet("Getsystemvehiclemodeldata")]
        
        public async Task<IEnumerable<Systemvehiclemodeldata>> Getsystemvehiclemodeldata()
        {
            return await bl.Getsystemvehiclemodeldata();
        }

        [HttpPost("Registersystemvehiclemodeldata")]
        public async Task<Genericmodel> Registersystemvehiclemodeldata(Systemvehiclemodels obj)
        {
            return await bl.Registersystemvehiclemodeldata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemvehiclemodeldatabyid/{Vehiclemodelid}")]
        public async Task<Systemvehiclemodels> Getsystemvehiclemodeldatabyid(long Vehiclemodelid)
        {
            return await bl.Getsystemvehiclemodeldatabyid(Vehiclemodelid);
        }
        #endregion


        #region System Tenants
        [HttpGet("Getsystemtenantdata")]
        public async Task<IEnumerable<Systemtenantdatamodel>> Getsystemtenantdata()
        {
            return await bl.Getsystemtenantdata();
        }

        [HttpPost("Registersystemtenantdata")]
        public async Task<Genericmodel> Registersystemtenantdata(Systemtenants obj)
        {
            return await bl.Registersystemtenantdata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemtenantdatabyid/{Tenantid}")]
        public async Task<Systemtenants> Getsystemtenantdatabyid(long Tenantid)
        {
            return await bl.Getsystemtenantdatabyid(Tenantid);
        }
        #endregion

        #region System Assets
        [HttpGet("Getsystemassetsdata")]
        public async Task<IEnumerable<Systemassetdatamodel>> Getsystemassetsdata()
        {
            return await bl.Getsystemassetsdata();
        }

        [HttpPost("Registersystemassetdata")]
        public async Task<Genericmodel> Registersystemassetdata(Systemassets obj)
        {
            return await bl.Registersystemassetdata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemassetdatabyid/{Assetid}")]
        public async Task<Systemassets> Getsystemassetdatabyid(long Assetid)
        {
            return await bl.Getsystemassetdatabyid(Assetid);
        }
        #endregion

    }
}
