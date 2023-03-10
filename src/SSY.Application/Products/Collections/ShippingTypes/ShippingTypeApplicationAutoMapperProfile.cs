using AutoMapper;
using SSY.Products.Collections.ShippingTypes.Dtos;

namespace SSY.Products.Collections.ShippingTypes;

public class ShippingTypeApplicationAutoMapperProfile : Profile
{
    public ShippingTypeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ShippingType, ShippingTypeDto>();
        CreateMap<CreateShippingTypeDto, ShippingType>();
        CreateMap<UpdateShippingTypeDto, ShippingType>();
    }
}