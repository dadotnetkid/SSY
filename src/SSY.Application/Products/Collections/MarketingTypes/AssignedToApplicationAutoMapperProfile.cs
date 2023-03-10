using AutoMapper;
using SSY.Products.Collections.MarketingTypes.Dtos;

namespace SSY.Products.Collections.MarketingTypes;

public class AssignedToApplicationAutoMapperProfile : Profile
{
    public AssignedToApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<MarketingType, MarketingTypeDto>();
        CreateMap<CreateMarketingTypeDto, MarketingType>();
        CreateMap<UpdateMarketingTypeDto, MarketingType>();
    }
}