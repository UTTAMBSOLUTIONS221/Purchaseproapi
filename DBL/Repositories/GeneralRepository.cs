using Dapper;
using System.Data.SqlClient;
using System.Data;
using DBL.Models;
using DBL.Entities;
using Newtonsoft.Json;
using DBL.Mpesamodels;

namespace DBL.Repositories
{
    public class GeneralRepository : BaseRepository, IGeneralRepository
    {
        public GeneralRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<ListModel> GetListModel(ListModelType listType)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);
                return connection.Query<ListModel>("Usp_Getlistmodel", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<ListModel> GetListModelbycode(ListModelType listType, long code)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);
                parameters.Add("@Code", code);
                return connection.Query<ListModel>("Usp_GetListModelbycode", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Genericmodel DeactivateorDeleteTableColumnData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_DeactivateorDeleteTableColumnData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RemoveTableColumnData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RemoveTableColumnData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }


        public Genericmodel Registermpesanotificationlogs(string Action, bool IsTxnSuccessfull, string ErrorMsg, SystemMpesaValidationReq ValidationReq, DateTime Now)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Action", Action);
                parameters.Add("@IsTxnSuccessFull", IsTxnSuccessfull);
                parameters.Add("@Response", ErrorMsg);
                parameters.Add("@DateCreated", Now);
                parameters.Add("@TransactionType", ValidationReq.TransactionType);
                parameters.Add("@TransID", ValidationReq.TransID);
                parameters.Add("@TransTime", ValidationReq.TransTime);
                parameters.Add("@TransAmount", Convert.ToDecimal(ValidationReq.TransAmount));
                parameters.Add("@BusinessShortCode", ValidationReq.BusinessShortCode);
                parameters.Add("@BillRefNumber", ValidationReq.BillRefNumber);
                parameters.Add("@InvoiceNumber", ValidationReq.InvoiceNumber);
                parameters.Add("@OrgAccountBalance", Convert.ToDecimal(ValidationReq.OrgAccountBalance));
                parameters.Add("@ThirdPartyTransId", ValidationReq.ThirdPartyTransID);
                parameters.Add("@MSISDN", ValidationReq.MSISDN);
                parameters.Add("@FirstName", ValidationReq.FirstName);
                parameters.Add("@MiddleName", ValidationReq.FirstName);
                parameters.Add("@LastName", ValidationReq.FirstName);
                return connection.Query<Genericmodel>("Usp_Registermpesanotificationlogs", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel Registermpesaapiresponselog(string Action, int StatusCode, bool IsSuccessful, string ErrorMsg, DateTime CreatedDate)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IsTxnSuccessFull", IsSuccessful);
                parameters.Add("@Action", Action);
                parameters.Add("@StatusCode", StatusCode);
                parameters.Add("@Response", ErrorMsg);
                parameters.Add("@DateCreated", CreatedDate);
                return connection.Query<Genericmodel>("Usp_Registermpesaapiresponselog", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel ProcessExprCallback(int serviceCode,string AccounNumber, ExprCallbackDataModel data)
        {
            using (IDbConnection Connection = new SqlConnection(_connString))
            {
                Connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Action","STKRESPONSE");
                parameters.Add("@IsTxnSuccessFull", true);
                parameters.Add("@Response", data.ResultDesc);
                parameters.Add("@DateCreated", DateTime.Now);
                parameters.Add("@TransactionType", "");
                parameters.Add("@TransID", data.RefNo);
                parameters.Add("@TransTime", DateTime.Now);
                parameters.Add("@TransAmount", Convert.ToDecimal(data.Amount));
                parameters.Add("@BusinessShortCode", serviceCode);
                parameters.Add("@BillRefNumber", AccounNumber);
                parameters.Add("@InvoiceNumber", data.CheckoutRequestID);
                parameters.Add("@OrgAccountBalance", data.Balance);
                parameters.Add("@ThirdPartyTransId", "");
                parameters.Add("@MSISDN", "");
                parameters.Add("@FirstName", "");
                parameters.Add("@MiddleName", "");
                parameters.Add("@LastName", "");
                parameters.Add("@ServiceCode", serviceCode);
                parameters.Add("@OrgRef", data.CheckoutRequestID);
                parameters.Add("@TxnID", data.RefNo);
                parameters.Add("@ResultCode", data.ResultCode);
                parameters.Add("@ResultDescr", data.ResultDesc);
                parameters.Add("@Receiver", data.CustomerDets);
                parameters.Add("@Amount", data.Amount);
                return Connection.Query<Genericmodel>("Usp_Registermpesastkapiresponselog", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel UpdatePayment3PStatus(string paymentRef, int status, string message)
        {
            using (IDbConnection Connection = new SqlConnection(_connString))
            {
                Connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RefNo", paymentRef);
                parameters.Add("@Stat", status);
                parameters.Add("@Msg", message);
                return Connection.Query<Genericmodel>("Usp_RegistermpesastkUpdatePayment3PStat", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }
}
