using Dapper;
using DBL.Entities;
using DBL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class SecurityRepository : BaseRepository, ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }

        public UsermodelResponce VerifySystemStaff(string Username)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                UsermodelResponce resp = new UsermodelResponce();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                parameters.Add("@StaffDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Verifysystemstaffs", parameters, commandType: CommandType.StoredProcedure);
                string staffDetailsJson = parameters.Get<string>("@StaffDetails");
                JObject responseJson = JObject.Parse(staffDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string userModelJson = responseJson["Usermodel"].ToString();
                    UsermodeldataResponce userResponse = JsonConvert.DeserializeObject<UsermodeldataResponce>(userModelJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = userResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = new UsermodeldataResponce();
                    return resp;
                }
            }
        }
        public IEnumerable<SystemStaffModel> Getsystemstaffsdata(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<SystemStaffModel>("Usp_Getsystemstaffsdata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemtaff(string JsonEntity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@JsonObjectdata", JsonEntity);
                return connection.Query<Genericmodel>("Usp_RegisterSystemstaffdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemcustomeruserdata(string JsonEntity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@JsonObjectdata", JsonEntity);
                return connection.Query<Genericmodel>("Usp_Registersystemcustomeruserdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemstaffs Getsystemstaffdatabyid(long StaffId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StaffId", StaffId);
                return connection.Query<Systemstaffs>("Usp_Getsystemstaffdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Resetuserpasswordpost(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Resetuserpasswordpostdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<SystemUserRoles> GetSystemRoles()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<SystemUserRoles>("Usp_GetSystemrolesdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterSystemStaffRole(string JsonEntity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@JsonObjectdata", JsonEntity);
                return connection.Query<Genericmodel>("Usp_Registersystemstaffrole", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
       
        public Systemuserroledetail GetSystemRoleDetailData(long RoleId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleId", RoleId);
                parameters.Add("@Roledetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemroledetaildatabyid", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@Roledetaildata");
                return JsonConvert.DeserializeObject<Systemuserroledetail>(roledetailDetailsJson);
            }
        }
    }
}
