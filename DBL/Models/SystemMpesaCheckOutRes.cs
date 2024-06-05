using DBL.Entities;

namespace DBL.Models
{
    public class SystemMpesaCheckOutRes
    {
        public Genericmodel? error { get; set; }
        public SystemMpesaCheckOutTxns? mpesaTxnDetails { get; set; }
    }
}
