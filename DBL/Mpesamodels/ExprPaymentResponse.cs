using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Models
{
    public class ExprPaymentResponse
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string CustomerMessage { get; set; }
    }
}
