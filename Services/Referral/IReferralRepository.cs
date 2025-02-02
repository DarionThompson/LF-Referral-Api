using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Referral
{
    public interface IReferralRepository
    {
        Task<ReferralDto> CreateReferralAsync(ReferralRequest request);
        Task<List<ReferralDto>> GetReferralsAsync(string referralUserId);
        Task<ReferralDto> GetReferralByCodeAndTrackingIdAsync(string referralCode, string referredTrackingId);
    }
}
