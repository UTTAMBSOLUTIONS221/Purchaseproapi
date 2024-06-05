namespace DBL.Models
{
    public class SystemStkPushCallBackRes
    {
        public Body? Body { get; set; }
    }
    public class Body
    {
        public StkCallback StkCallback { get; set; }
    }
    public class StkCallback
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public CallbackMetadata CallbackMetadata { get; set; }
    }

    public class CallbackMetadata
    {
        public List<Item> Item { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
