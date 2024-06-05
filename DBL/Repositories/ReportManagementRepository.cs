using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DBL.Repositories
{
    public class ReportManagementRepository:BaseRepository,IReportManagementRepository
    {
        public ReportManagementRepository(string connectionString) : base(connectionString)
        {
        }
        public Systemreportdataandparameters Getsystemloanrepaymentdata(long TenantId, long Customerid, long Assetdetailid, long Loanstatus, DateTime Startdate, DateTime Enddate)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                Systemreportdataandparameters resp = new Systemreportdataandparameters();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Customerid", Customerid);
                parameters.Add("@Assetdetailid", Assetdetailid);
                parameters.Add("@Loanstatus", Loanstatus);
                parameters.Add("@Startdate", Startdate);
                parameters.Add("@Enddate", Enddate);
                parameters.Add("@CustomerReportDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Generatecustomerloanpaymentreport", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@CustomerReportDetails");
                JObject responseJson = JObject.Parse(roledetailDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string loandetaillJson = responseJson["Loanrepaymentreportdata"].ToString();
                    List<Systemloanrepaymentmodel> loanDetailResponse = JsonConvert.DeserializeObject<List<Systemloanrepaymentmodel>>(loandetaillJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Customername = responseJson["Customername"].ToString();
                    resp.Assetdetailname = responseJson["Assetdetailname"].ToString();
                    resp.Loanstatusname = responseJson["Loanstatusname"].ToString();
                    resp.Loanrepaymentreportdata = loanDetailResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Customername = responseJson["Customername"].ToString();
                    resp.Assetdetailname = responseJson["Assetdetailname"].ToString();
                    resp.Loanstatusname = responseJson["Loanstatusname"].ToString();
                    resp.Loanrepaymentreportdata = new List<Systemloanrepaymentmodel>();
                    return resp;
                }
            }
        }
    }
}
