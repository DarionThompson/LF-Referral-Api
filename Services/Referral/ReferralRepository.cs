using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<ReferralDto> CreateReferralAsync(ReferralRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ReferralDto> GetReferralByCodeAndTrackingIdAsync(string referralCode, string referredTrackingId)
        {
            throw new NotImplementedException();
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
