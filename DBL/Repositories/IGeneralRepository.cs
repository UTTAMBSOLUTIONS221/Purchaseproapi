using DBL.Entities;
using DBL.Models;
using DBL.Mpesamodels;

namespace DBL.Repositories
{
    public interface IGeneralRepository
    {
        IEnumerable<ListModel> GetListModel(ListModelType listType);
        IEnumerable<ListModel> GetListModelbycode(ListModelType listType, long code);
        Genericmodel DeactivateorDeleteTableColumnData(string jsonObjectdata);
        Genericmodel RemoveTableColumnData(string jsonObjectdata);
        Genericmodel Registermpesanotificationlogs(string Action, bool IsTxnSuccessfull, string ErrorMsg, SystemMpesaValidationReq ValidationReq, DateTime Now);
        Genericmodel Registermpesaapiresponselog(string Action, int StatusCode, bool IsSuccessful, string ErrorMsg, DateTime CreatedDate);
        Genericmodel ProcessExprCallback(int serviceCode, string AccounNumber, ExprCallbackDataModel data);
        Genericmodel UpdatePayment3PStatus(string paymentRef, int status, string message);
    }
}
