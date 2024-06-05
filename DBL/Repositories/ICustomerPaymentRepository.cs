using DBL.Entities;
using DBL.Models;
using DBL.Mpesamodels;

namespace DBL.Repositories
{
    public interface ICustomerPaymentRepository
    {
        Genericmodel GetB2CSettings(int serviceCode);
        Genericmodel GetExprSettings(int serviceCode);
        Genericmodel CreatePayment(Payment entity);
        BaseEntity UpdateMPesa(string txnRef, int status, string message, string newRef = "");
        BaseEntity UpdatePayment3PStatus(string paymentRef, int status, string message);
        Genericmodel ProcessB2CResult(int serviceCode, B2CResultData data);
        Genericmodel ProcessExprCallback(int serviceCode, ExprCallbackDataModel data);
    }
}
