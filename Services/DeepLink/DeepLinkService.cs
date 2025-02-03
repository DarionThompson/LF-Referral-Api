using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DeepLink
{
    public class DeepLinkService : IDeepLinkService
    {
        public async Task<GeneratedLinkResponse> GetDeepLinkUrlAync(ReferralRequest request)
        {
            return new GeneratedLinkResponse
            {
                Link = $"https://urlgeni.us/X_mKB/{request.ReferralCode}/{request.ReferredTrackingId}",
            };
        }
    }
}
