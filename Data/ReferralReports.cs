using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace Data
{
    [Table("ReferralReports")]
    public class ReferralReports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ReferralId")]
        public int ReferralId { get; set; }

        [Required]
        public string Reason { get; set; }

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        public Referrals Referral { get; set; }
    }
}
