using AutoMapper;
using SSY.Products.Options.Dtos;

namespace SSY.Products.Options;

public class OptionApplicationAutoMapperProfile : Profile
{
    public OptionApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Option, OptionDto>();
        CreateMap<CreateOptionDto, Option>();
        CreateMap<UpdateOptionDto, Option>();
    }
}