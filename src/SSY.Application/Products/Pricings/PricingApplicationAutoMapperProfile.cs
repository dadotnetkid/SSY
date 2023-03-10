using AutoMapper;
using SSY.Products.Pricings.Dtos;

namespace SSY.Products.Pricings;

public class PricingApplicationAutoMapperProfile : Profile
{
    public PricingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Pricing, PricingDto>();
        CreateMap<CreatePricingDto, Pricing>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            ;
        CreateMap<UpdatePricingDto, Pricing>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            ;
    }
}