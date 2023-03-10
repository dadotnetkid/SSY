using AutoMapper;
using SSY.Products.Collections.ColorOptions.Dtos;

namespace SSY.Products.Collections.ColorOptions;

public class ColorOptionApplicationAutoMapperProfile : Profile
{
    public ColorOptionApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ColorOption, ColorOptionDto>();
        CreateMap<CreateColorOptionDto, ColorOption>();
        CreateMap<UpdateColorOptionDto, ColorOption>();

        CreateMap<ColorOptionProductType, ColorOptionProductTypeDto>();
        CreateMap<CreateColorOptionProductTypeDto, ColorOptionProductType>();
        CreateMap<UpdateColorOptionProductTypeDto, ColorOptionProductType>();

        CreateMap<ColorOptionFabric, ColorOptionFabricDto>();
        CreateMap<CreateColorOptionFabricDto, ColorOptionFabric>();
        CreateMap<UpdateColorOptionFabricDto, ColorOptionFabric>();

        CreateMap<ColorOptionFabricRoll, ColorOptionFabricRollDto>();
        CreateMap<CreateColorOptionFabricRollDto, ColorOptionFabricRoll>();
        CreateMap<UpdateColorOptionFabricRollDto, ColorOptionFabricRoll>();
    }
}