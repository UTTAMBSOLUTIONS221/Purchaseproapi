using DBL;
using Microsoft.AspNetCore.Mvc;
using MPesaAPI.Models;
using System.Text;

namespace Purchaseproapi.Controllers
{
    [Produces("application/json")]
    public class MPesaController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public MPesaController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config), config);
            _config = config;
        }

        #region MPESA C2B
        [HttpPost("api/v1/channelm/expr/callback/{id}")]
        public async Task MPesaSTKPushCallback(int id)
        {
            try
            {
                //---- Read data
                string content = "";
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    content = await reader.ReadToEndAsync();
                }

                Util.LogError("Pesa-STKPushCallback", new Exception(content), false);
                bl.ProcessMPesaSTKCallback(id, content);
            }
            catch (Exception ex)
            {
                Util.LogError("Pesa-MPesaSTKPushCallback", ex);
            }
        }
        [HttpPost("api/v1/channelm/c2b/registermpesaurl")]
        public async Task<RegisterC2BUrlResponseData> MpesaRegisterValidationURL(C2BConfirmData Request)
        {
            return await bl.MpesaRegisterValidationURL(Request);

        }
        [HttpPost("api/v1/channelm/c2b/validate/{Assetnumber}")]
        public async Task<C2BValidationResp> Validation(string Assetnumber)
        {
            try
            {
                var resp = await bl.Validateexistenceoftheaccount(Assetnumber);
                //---- Read data
                string content = "";
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    content = await reader.ReadToEndAsync();
                }

                Util.LogError("C2B-Validation", new Exception(content), false);
                //await bl.ProcessMPesaSTKCallback(content);
            }
            catch (Exception ex)
            {
                Util.LogError("C2B-Validation", ex);
            }

            return new C2BValidationResp
            {
                ResultCode = 0,
                ResultDesc = "Success",
                ThirdPartyTransID = new Random().Next(100000, 999999).ToString()
            };
        }

        [HttpPost("api/v1/channelm/c2b/confirm/{Assetnumber}")]
        public async Task<C2BConfirmResp> Confirmation(string Assetnumber)
        {
            try
            {
                //---- Read data
                string content = "";
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    content = await reader.ReadToEndAsync();
                }

                Util.LogError("C2B-Confirmation >> No:" + Assetnumber, new Exception(content), false);
                bl.ProcessC2BConfirmation(Assetnumber, content);
            }
            catch (Exception ex)
            {
                Util.LogError("C2B-Confirmation", ex);
            }

            return new C2BConfirmResp
            {
                ResultCode = 0,
                ResultDesc = "Success"
            };
        }
        #endregion
    }
}