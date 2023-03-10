using AutoMapper;
using SSY.Products.Collections.Factories.Dtos;

namespace SSY.Products.Collections.Factories;

public class FactoryApplicationAutoMapperProfile : Profile
{
    public FactoryApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Factory, FactoryDto>();
        CreateMap<CreateFactoryDto, Factory>();
        CreateMap<UpdateFactoryDto, Factory>();
    }
}