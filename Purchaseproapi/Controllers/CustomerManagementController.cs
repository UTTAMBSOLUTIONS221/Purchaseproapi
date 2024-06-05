using DBL;
using DBL.Entities;
using DBL.Models;
using DBL.Mpesamodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public CustomerManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }
        [HttpGet("Getsystemcustomers/{TenantId}")]
        public async Task<IEnumerable<Systemcustomerdatamodel>> Getsystemcustomers(long TenantId)
        {
            return await bl.Getsystemcustomerdata(TenantId);
        }
        [HttpPost("Registersystemcustomer")]
        public async Task<Genericmodel> Registersystemcustomer(Systemcustomerdetail obj)
        {
            return await bl.Registersystemcustomerdata(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("Registersystemcustomeruserdata")]
        public async Task<Genericmodel> Createsystemcustomeruserdata(Systemcustomerdetail obj)
        {
            return await bl.Createsystemcustomeruserdata(obj);
        }
        [HttpGet("Getsystemcustomerdetaildata/{CustomerId}")]
        public async Task<Systemcustomerdetail> Getsystemcustomerdetaildata(long CustomerId)
        {
            return await bl.Getsystemcustomerdetaildatabyid(CustomerId);
        }
        [HttpPost("Registersystemcustomerloandetail")]
        public async Task<Genericmodel> Registersystemcustomerloandetail(Customerloandetailsdata obj)
        {
            return await bl.Registersystemcustomerloandetaildata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemcustomerloandetaildata/{CustomerId}")]
        public async Task<Systemcustomerdetaildatamodel> Getsystemcustomerloandetaildata(long CustomerId)
        {
            return await bl.Getsystemcustomerloandetaildata(CustomerId);
        }

        [HttpPost("Expresspayloaninvoiceitemdata")]
        public async Task<PayResponse> Expresspayloaninvoiceitemdata(PesaAppRequestData obj)
        {
            return await bl.MakeExpressPayment(obj);
        }
        [HttpPost("DeactivateorDeleteTableColumnData")]
        public async Task<Genericmodel> DeactivateorDeleteTableColumnData(ActivateDeactivateActions obj)
        {
            return await bl.DeactivateorDeleteTableColumnData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("RemoveTableColumnData")]
        public async Task<Genericmodel> RemoveTableColumnData(ActivateDeactivateActions obj)
        {
            return await bl.RemoveTableColumnData(JsonConvert.SerializeObject(obj));
        }
    }
}
