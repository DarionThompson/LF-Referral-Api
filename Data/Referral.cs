using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Table("Referral")]
    public class Referral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ReferrerUserId { get; set; } 

        [Required]
        public string ReferralCode { get; set; } 

        public string? ReferredUser { get; set; } 

        [Required]
        public string Status { get; set; } = "Pending"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<ReferralTracking> Clicks { get; set; } = new();

        public List<ReferralReports> ReferralReports { get; set; } = new();
    }
}
