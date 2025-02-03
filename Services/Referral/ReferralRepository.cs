using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Referral
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly ReferralDbContext _dbContext;

        private readonly IMapper _mapper;

        public ReferralRepository(ReferralDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateReferralAsync(ReferralRequest request)
        {
            var referral = new Referrals
            {
                ReferrerUserId = request.ReferrerUserId,
                ReferralCode = request.ReferralCode,
                ReferredUserEmail = request.ReferredUserEmail,
                RefferedTrackingId = request.ReferredTrackingId
            };
            await _dbContext.Referrals.AddAsync(referral);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<ReferralDto>> GetReferralsAsync(string referralUserId)
        {
            var query = _dbContext.Referrals.AsQueryable();

            query = query.Where(query => query.ReferrerUserId == referralUserId);

            var referrals = await query.AsNoTracking().ToListAsync();

            var referralsDto = _mapper.Map<List<ReferralDto>>(referrals);

            return referralsDto;
        }
    }
}
