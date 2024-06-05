using System;
using System.Collections.Generic;
using System.Text;

namespace MPesaAPI.Models
{
    public class B2CPaymentRespone
    {
        public string ConversationID { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }
}
