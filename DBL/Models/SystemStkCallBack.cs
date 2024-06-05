namespace DBL.Models
{
    public class SystemStkCallBack
    {
        public string? MerchantRequestID { get; set; }
        public string? CheckoutRequestID { get; set; }
        public string? ResultCode { get; set; }
        public string? ResultDesc { get; set; }
        public SystemCallbackMetadata? CallbackMetadata { get; set; }
    }
}
