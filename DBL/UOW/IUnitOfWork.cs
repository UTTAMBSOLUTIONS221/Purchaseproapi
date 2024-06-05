using DBL.Repositories;

namespace DBL.UOW
{
    public interface IUnitOfWork
    {
        IGeneralRepository GeneralRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        IMaintenanceRepository MaintenanceRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerPaymentRepository CustomerPaymentRepository { get; }
        IReportManagementRepository ReportManagementRepository { get; }
    }
}
