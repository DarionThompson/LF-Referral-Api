using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DeepLink
{
    public interface IDeepLinkService
    {
        Task<GeneratedLinkResponse> GetDeepLinkUrlAync(ReferralRequest request);                                                    
    }
}
