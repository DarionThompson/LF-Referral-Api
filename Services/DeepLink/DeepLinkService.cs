using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DeepLink
{
    public class DeepLinkService : IDeepLinkService
    {
        public Task<string> GetDeepLinkUrlAync(string referralCode, string referredSource)
        {
            throw new NotImplementedException();
        }
    }
}
