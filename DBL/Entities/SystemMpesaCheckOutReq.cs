namespace DBL.Entities
{
    public class SystemMpesaCheckOutReq
    {
        public string? Authurl { get; set; }
        public string? Sandboxsimurl { get; set; }
        public string? Mpesacallbackurl { get; set; }
        public string? Consumerkey { get; set; }
        public string? Consumersecret { get; set; }
        public string? Shortcode { get; set; }
        public string? Passkey { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
