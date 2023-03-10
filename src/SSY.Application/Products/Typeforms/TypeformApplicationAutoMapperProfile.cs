using AutoMapper;
using SSY.Products.Typeforms.Dtos;

namespace SSY.Products.Typeforms;

public class TypeApplicationAutoMapperProfile : Profile
{
    public TypeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Typeform, TypeformDto>();
        CreateMap<CreateTypeformDto, Typeform>();
        CreateMap<UpdateTypeformDto, Typeform>();
    }
}