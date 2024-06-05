using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public ReportManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }
        [HttpGet("Generatesystemloanrepaymentdata/{TenantId}/{Customerid}/{Assetdetailid}/{Loanstatus}/{Startdate}/{Enddate}")]
        public async Task<Systemreportdataandparameters> Getsystemloanrepaymentdata(long TenantId, long Customerid,long Assetdetailid, long Loanstatus, DateTime Startdate, DateTime Enddate)
        {
            return await bl.Getsystemloanrepaymentdata(TenantId, Customerid, Assetdetailid, Loanstatus, Startdate, Enddate);
        }
    }
}
