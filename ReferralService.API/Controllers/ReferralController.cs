using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DeepLink;
using Services.Models;
using Services.Referral;
using Services.Users;

namespace ReferralService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IDeepLinkService _deepLinkService;
        private readonly IUserService _userService;

        public ReferralController(IReferralRepository referralRepository, IDeepLinkService deepLinkService, IUserService userService)
        {
            _referralRepository = referralRepository;
            _deepLinkService = deepLinkService;
            _userService = userService;
        }

        [HttpPost("generate-link")]
        public async Task<IActionResult> GenerateReferralLink([FromBody] ReferralRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ReferrerUserId))
                return BadRequest("Referrer UserID is required");

            if (string.IsNullOrWhiteSpace(request.ReferralCode))
                return BadRequest("Referral Code is required");

            if (string.IsNullOrWhiteSpace(request.ReferredUserEmail))
                return BadRequest("Referrer User Email is required");

            var isExistingUser = await _userService.CheckIfUserExistsAsync(request.ReferredUserEmail);

            if(isExistingUser)
            {
                return Conflict("User is already registered and cannot be referred.");
            }

            var deepLinkResponse = await _deepLinkService.GetDeepLinkUrlAync(request);

            await _referralRepository.CreateReferralAsync(request);

            return CreatedAtAction(nameof(GenerateReferralLink), new ReferralResponse { DeepLink = deepLinkResponse.Link});
        }

        [HttpGet("get-referrals")]
        public async Task<IActionResult> GetUserReferralsbyId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("User Id is required");

            var result = await _referralRepository.GetReferralsAsync(userId);

            return Ok(result);
        }
    }
}
