﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Models
{
    public class PaymentNotificationResp
    {
        [JsonProperty("stat")]
        public int Status { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
