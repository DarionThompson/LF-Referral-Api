using AutoMapper;
using Data.Entities;
using Services.Models;

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Referrals, ReferralDto>().ReverseMap();
        }
    }
}
