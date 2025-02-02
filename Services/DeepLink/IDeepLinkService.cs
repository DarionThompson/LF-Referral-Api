using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DeepLink
{
    public interface IDeepLinkService
    {
        Task<string> GetDeepLinkUrlAync(string referralCode, string referredSource);                                                    
    }
}
