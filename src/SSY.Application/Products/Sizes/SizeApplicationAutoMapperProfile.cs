using AutoMapper;
using SSY.Products.Sizes.Dtos;

namespace SSY.Products.Sizes;

public class SizeApplicationAutoMapperProfile : Profile
{
    public SizeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Size, SizeDto>();
        CreateMap<CreateSizeDto, Size>();
        CreateMap<UpdateSizeDto, Size>();
    }
}