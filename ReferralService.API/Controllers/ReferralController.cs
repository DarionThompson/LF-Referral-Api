using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DeepLink;
using Services.Models;
using Services.Referral;

namespace ReferralService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IDeepLinkService _deepLinkService;

        public ReferralController(IReferralRepository referralRepository, IDeepLinkService deepLinkService)
        {
            _referralRepository = referralRepository;
            _deepLinkService = deepLinkService;
        }

        [HttpPost("generate-link")]
        public async Task<IActionResult> GenerateReferralLink([FromBody] ReferralRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ReferrerUserId))
                return BadRequest("Referrer UserID is required");

            if (string.IsNullOrWhiteSpace(request.ReferralCode))
                return BadRequest("Referrer code is required");

            if (string.IsNullOrWhiteSpace(request.ReferredSource))
                return BadRequest("Referrer Source is required");

            var deepLinkUrl = await _deepLinkService.GetDeepLinkUrlAync(request.ReferralCode, request.ReferredSource);

            var response = await _referralRepository.CreateReferralAsync(request);

            return Ok(new ReferralResponse { DeepLink = deepLinkUrl, ReferralCode = response.ReferralCode });
        }

        [HttpGet]
        public async Task<IActionResult> GetUserReferrals(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("UserID is required");

            var result = await _referralRepository.GetReferralsAsync(userId);

            return Ok(result);
        }
    }
}
