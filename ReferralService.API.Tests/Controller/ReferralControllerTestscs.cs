using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReferralService.API.Controllers;
using Services.DeepLink;
using Services.Models;
using Services.Referral;

namespace ReferralService.API.Tests.Controller
{
    public class ReferralControllerTestscs
    {
        private readonly Mock<IDeepLinkService> _mockDeepLinkService;
        private readonly Mock<IReferralRepository> _mockReferralRepository;
        private readonly ReferralController _sut;

        public ReferralControllerTestscs()
        {
            _mockDeepLinkService = new Mock<IDeepLinkService>();
            _mockReferralRepository = new Mock<IReferralRepository>();
            _sut = new ReferralController(_mockReferralRepository.Object, _mockDeepLinkService.Object);
        }

        [Fact]
        public async Task GenerateReferralLink_WithNoId_ShouldReturnBadReqest()
        {
            var testRequest = new ReferralRequest { ReferralCode = "XY7G4D" };

            var result = await _sut.GenerateReferralLink(testRequest);

            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Referrer UserID is required");
        }

        [Fact]
        public async Task GenerateReferralLink_WithNoReferralCode_ShouldReturnBadReqest()
        {
            var testRequest = new ReferralRequest { ReferrerUserId = "janedoe@nothingspecific.com" };

            var result = await _sut.GenerateReferralLink(testRequest);

            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Referrer code is required");
        }

        [Fact]
        public async Task GenerateReferralLink_WithNoReferralEmail_ShouldReturnBadReqest()
        {
            var testRequest = new ReferralRequest 
            { 
                ReferralCode = "XY7G4D",
                ReferrerUserId = "janedoe@nothingspecific.com"
            };

            var result = await _sut.GenerateReferralLink(testRequest);

            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Referrer User Emails is required");
        }
    }
}
