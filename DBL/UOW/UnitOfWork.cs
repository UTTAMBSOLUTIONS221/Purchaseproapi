using DBL.Repositories;

namespace DBL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private IGeneralRepository generalRepository;
        private ISecurityRepository securityRepository;
        private IMaintenanceRepository maintenanceRepository;
        private ICustomerRepository customerRepository;
        private ICustomerPaymentRepository customerPaymentRepository;
        private IReportManagementRepository reportManagementRepository;

        public UnitOfWork(string connectionString) => connString = connectionString;
        public IGeneralRepository GeneralRepository
        {
            get { return generalRepository ?? (generalRepository = new GeneralRepository(connString)); }
        }
        public ISecurityRepository SecurityRepository
        {
            get { return securityRepository ?? (securityRepository = new SecurityRepository(connString)); }
        }
        public IMaintenanceRepository MaintenanceRepository
        {
            get { return maintenanceRepository ?? (maintenanceRepository = new MaintenanceRepository(connString)); }
        }
        public ICustomerRepository CustomerRepository
        {
            get { return customerRepository ?? (customerRepository = new CustomerRepository(connString)); }
        } 
        public ICustomerPaymentRepository CustomerPaymentRepository
        {
            get { return customerPaymentRepository ?? (customerPaymentRepository = new CustomerPaymentRepository(connString)); }
        }
        public IReportManagementRepository ReportManagementRepository
        {
            get { return reportManagementRepository ?? (reportManagementRepository = new ReportManagementRepository(connString)); }
        }
        public void Reset()
        {
            generalRepository = null;
            securityRepository = null;
            maintenanceRepository = null;
            customerRepository = null;
            customerPaymentRepository = null;
            reportManagementRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
