using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace Data
{
    [Table("ReferralTracking")]
    public class ReferralTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ReferralId")]
        public int ReferralId { get; set; }

        public string DeviceId { get; set; }

        [Required]
        public string Source { get; set; }

        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;

        public Referrals Referral { get; set; }
    }
}
