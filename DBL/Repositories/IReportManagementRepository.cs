using DBL.Models;

namespace DBL.Repositories
{
    public interface IReportManagementRepository
    {
        Systemreportdataandparameters Getsystemloanrepaymentdata(long TenantId, long Customerid, long Assetdetailid, long Loanstatus, DateTime Startdate, DateTime Enddate);
    }
}
