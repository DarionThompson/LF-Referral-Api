﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ReferralRequest
    {
        public string ReferrerUserId { get; set; }

        public string ReferralCode { get; set; }

        public string ReferredUserEmail { get; set; }

        public Guid ReferredTrackingId { get; set; } = Guid.NewGuid();
    }
}
