using Dapper;
using DBL.Entities;
using DBL.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DBL.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Systemcustomerdatamodel> Getsystemcustomerdata(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<Systemcustomerdatamodel>("Usp_Getsystemcustomerdata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemcustomerdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemcustomerdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemcustomerdetail Getsystemcustomerdetaildatabyid(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Customerid", CustomerId);
                return connection.Query<Systemcustomerdetail>("Usp_Getsystemcustomerdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemcustomerloandetaildata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemcustomerloandetaildata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemcustomerdetaildatamodel Getsystemcustomerloandetaildata(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Customerid", CustomerId);
                parameters.Add("@CustomerDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemcustomerdetaildata", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@CustomerDetails");
                return JsonConvert.DeserializeObject<Systemcustomerdetaildatamodel>(roledetailDetailsJson);
            }
        }
        public Genericmodel Getsystemcustomerdetaildatabyassetnumber(string Assetnumber)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Assetnumber", Assetnumber);
                return connection.Query<Genericmodel>("Usp_Getsystemcustomerdetaildatabyassetnumber", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Payloaninvoiceitemdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Payloaninvoiceitemdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
