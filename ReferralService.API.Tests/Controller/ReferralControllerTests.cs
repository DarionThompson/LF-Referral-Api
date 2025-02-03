using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReferralService.API.Controllers;
using Services.DeepLink;
using Services.Models;
using Services.Referral;
using Services.Users;

namespace ReferralService.API.Tests.Controller
{
    public class ReferralControllerTests
    {
        private readonly Mock<IDeepLinkService> _mockDeepLinkService;
        private readonly Mock<IReferralRepository> _mockReferralRepository;
        private readonly Mock<IUserService> _mockUserService;
        private readonly ReferralController _sut;

        public ReferralControllerTests()
        {
            _mockDeepLinkService = new Mock<IDeepLinkService>();
            _mockReferralRepository = new Mock<IReferralRepository>();
            _mockUserService = new Mock<IUserService>();

            _mockUserService.Setup(x => x.CheckIfUserExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _sut = new ReferralController(_mockReferralRepository.Object, _mockDeepLinkService.Object, _mockUserService.Object);
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
                .Which.Value.Should().Be("Referral Code is required");
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
                .Which.Value.Should().Be("Referrer User Email is required");
        }

        [Fact]
        public async Task GenerateReferralLink_WithExistingUser_ShouldReturnConflict()
        {
            var testRequest = new ReferralRequest
            {
                ReferralCode = "XY7G4D",
                ReferrerUserId = "jonedoe@nothingspecific.com",
                ReferredUserEmail = "janedoe@nothingspecific.com"
            };

            _mockUserService.Setup(x => x.CheckIfUserExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            var result = await _sut.GenerateReferralLink(testRequest);

            result.Should().BeOfType<ConflictObjectResult>()
                .Which.Value.Should().Be("User is already registered and cannot be referred.");
        }

        [Fact]
        public async Task GetUserReferrals_WithNoUserId_ShouldReturnBadReqest()
        {

            var result = await _sut.GetUserReferralsbyId(string.Empty);

            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("User Id is required");
        }
    }
}
