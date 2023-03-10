using AutoMapper;
using SSY.Products.Collections.PricePoints.Dtos;

namespace SSY.Products.Collections.PricePoints;

public class PricePointApplicationAutoMapperProfile : Profile
{
    public PricePointApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<PricePoint, PricePointDto>();
        CreateMap<CreatePricePointDto, PricePoint>();
        CreateMap<UpdatePricePointDto, PricePoint>();
    }
}