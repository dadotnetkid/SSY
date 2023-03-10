using AutoMapper;
using SSY.Products.Collections.Drops.Dtos;

namespace SSY.Products.Collections.Drops;

public class DropApplicationAutoMapperProfile : Profile
{
    public DropApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Drop, DropDto>();
        CreateMap<CreateDropDto, Drop>();
        CreateMap<UpdateDropDto, Drop>();
    }
}