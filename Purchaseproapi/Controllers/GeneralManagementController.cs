using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Purchaseproapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class GeneralManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public GeneralManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }
        [HttpGet("Systemdropdowns")]
        public List<ListModel> Systemdropdowns(ListModelType listType)
        {
            return bl.GetListModel(listType).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value,
                GroupId = x.GroupId,
                GroupName = x.GroupName,
            }).ToList();
        }

        [HttpGet("SystemdropdownbyId/{Id}")]
        public List<ListModel> SystemdropdownbyId(ListModelType listType, long Id)
        {
            return bl.GetListModelById(listType, Id).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
        }
    }
}
