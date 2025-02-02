using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ReferralDto
    {
        public int Id { get; set; }

        public string ReferrerUserId { get; set; }

        public string ReferralCode { get; set; }

        public string ReferredUserEmail { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
