using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Systemcustomerdatamodel> Getsystemcustomerdata(long TenantId);
        Genericmodel Registersystemcustomerdata(string jsonObjectdata);
        Systemcustomerdetail Getsystemcustomerdetaildatabyid(long CustomerId);
        Genericmodel Registersystemcustomerloandetaildata(string jsonObjectdata);
        Systemcustomerdetaildatamodel Getsystemcustomerloandetaildata(long CustomerId);
        Genericmodel Getsystemcustomerdetaildatabyassetnumber(string Assetnumber);
        Genericmodel Payloaninvoiceitemdata(string jsonObjectdata);
    }
}
