using AutoMapper;
using SSY.Products.Types.Dtos;

namespace SSY.Products.Types;

public class TypeApplicationAutoMapperProfile : Profile
{
    public TypeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Type, TypeDto>();
        CreateMap<CreateTypeDto, Type>();
        CreateMap<UpdateTypeDto, Type>();

        CreateMap<TypeOption, TypeOptionDto>();
        CreateMap<CreateTypeOptionDto, TypeOption>()
        .ForMember(x => x.Option, opt => opt.Ignore());
        CreateMap<UpdateTypeOptionDto, TypeOption>()
        .ForMember(x => x.Option, opt => opt.Ignore());

        CreateMap<BaseSizeSpec, BaseSizeSpecDto>();
        CreateMap<CreateBaseSizeSpecDto, BaseSizeSpec>()
        .ForMember(x => x.MediaFile, opt => opt.Ignore());
        CreateMap<UpdateBaseSizeSpecDto, BaseSizeSpec>()
        .ForMember(x => x.MediaFile, opt => opt.Ignore());

        CreateMap<ObjBlockPattern, OBJBlockPatternDto>();
        CreateMap<CreateOBJBlockPatternDto, ObjBlockPattern>()
        .ForMember(x => x.MediaFile, opt => opt.Ignore());
        CreateMap<UpdateOBJBlockPatternDto, ObjBlockPattern>()
        .ForMember(x => x.MediaFile, opt => opt.Ignore());
    }
}