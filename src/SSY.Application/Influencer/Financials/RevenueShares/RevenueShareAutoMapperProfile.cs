using AutoMapper;
using SSY.Influencer.Financials.RevenueShares.Dto;
using SSY.Influencers.RevenueShares;

namespace SSY.Influencer.Financials.RevenueShares;

public class RevenueShareAutoMapperProfile : Profile
{
    public RevenueShareAutoMapperProfile()
    {
        CreateMap<RevenueShare, RevenueShareDto>().ReverseMap();
        CreateMap<RevenueShare, CreateRevenueShareDto>().ReverseMap();
        CreateMap<RevenueShare, UpdateRevenueShareDto>().ReverseMap();
        CreateMap<RevenueShareDto, CreateRevenueShareDto>().ReverseMap();
        CreateMap<RevenueShareDto, UpdateRevenueShareDto>().ReverseMap();
    }
}