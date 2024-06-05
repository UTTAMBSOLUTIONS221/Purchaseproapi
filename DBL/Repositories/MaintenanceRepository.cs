using Dapper;
using DBL.Entities;
using DBL.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DBL.Repositories
{
    public class MaintenanceRepository : BaseRepository, IMaintenanceRepository
    {
        public MaintenanceRepository(string connectionString) : base(connectionString)
        {
        }

        #region System Permissions
        public IEnumerable<Systempermissions> Getsystempermissiondata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systempermissions>("Usp_Getsystempermissiondata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystempermissiondata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystempermissiondata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systempermissions Getsystempermissiondatabyid(long Permissionid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Permissionid", Permissionid);
                return connection.Query<Systempermissions>("Usp_Getsystempermissiondatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Vehicle Makes
        public IEnumerable<Systemvehiclemakes> Getsystemvehiclemakedata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systemvehiclemakes>("Usp_Getsystemvehiclemakedata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemvehiclemakedata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemvehiclemakedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemvehiclemakes Getsystemvehiclemakedatabyid(long Vehiclemakeid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Vehiclemakeid", Vehiclemakeid);
                return connection.Query<Systemvehiclemakes>("Usp_Getsystemvehiclemakedatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Vehicle Models
        public IEnumerable<Systemvehiclemodeldata> Getsystemvehiclemodeldata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systemvehiclemodeldata>("Usp_Getsystemvehiclemodeldata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemvehiclemodeldata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemvehiclemodeldata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemvehiclemodels Getsystemvehiclemodeldatabyid(long Vehiclemodelid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Vehiclemodelid", Vehiclemodelid);
                return connection.Query<Systemvehiclemodels>("Usp_Getsystemvehiclemodeldatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion


        #region System Tenants
        public IEnumerable<Systemtenantdatamodel> Getsystemtenantdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systemtenantdatamodel>("Usp_Getsystemtenantdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemtenantdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemtenantdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemtenants Getsystemtenantdatabyid(long Tenantid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantid", Tenantid);
                return connection.Query<Systemtenants>("Usp_Getsystemtenantdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Assets
        public IEnumerable<Systemassetdatamodel> Getsystemassetsdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systemassetdatamodel>("Usp_Getsystemassetsdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemassetdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemassetdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemassets Getsystemassetdatabyid(long Assetid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Assetid", Assetid);
                return connection.Query<Systemassets>("Usp_Getsystemassetdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

    }
}
