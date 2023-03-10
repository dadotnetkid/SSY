using AutoMapper;
using SSY.Products.Collections.AssignedTos;
using SSY.Products.Collections.AssignedTos.Dtos;
using SSY.Products.Collections.ColorOptions;
using SSY.Products.Collections.ColorOptions.Dtos;
using SSY.Products.Collections.Dtos;

namespace SSY.Products.Collections;

public class CollectionApplicationAutoMapperProfile : Profile
{
    public CollectionApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Collection, CollectionDto>();
        CreateMap<CreateCollectionDto, Collection>()
            .ForMember(x => x.DesignStatus, opt => opt.Ignore())
            .ForMember(x => x.Factory, opt => opt.Ignore())
            .ForMember(x => x.MarketingType, opt => opt.Ignore())
            .ForMember(x => x.Season, opt => opt.Ignore())
            .ForMember(x => x.ShippingType, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.Ignore())
            ;
        CreateMap<UpdateCollectionDto, Collection>()
            .ForMember(x => x.DesignStatus, opt => opt.Ignore())
            .ForMember(x => x.Factory, opt => opt.Ignore())
            .ForMember(x => x.MarketingType, opt => opt.Ignore())
            .ForMember(x => x.Season, opt => opt.Ignore())
            .ForMember(x => x.ShippingType, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.Ignore())
            ;

        CreateMap<CollectionInfluencer, CollectionInfluencerDto>();
        CreateMap<CreateCollectionInfluencerDto, CollectionInfluencer>();
        CreateMap<UpdateCollectionInfluencerDto, CollectionInfluencer>();

        CreateMap<CollectionProductType, CollectionProductTypeDto>();
        CreateMap<CreateCollectionProductTypeDto, CollectionProductType>()
            .ForMember(x => x.ProductType, opt => opt.Ignore())
            ;
        CreateMap<UpdateCollectionProductTypeDto, CollectionProductType>()
            .ForMember(x => x.ProductType, opt => opt.Ignore())
            ;

        CreateMap<UpdateAssignedToDto, AssignedTo>()
           .ForMember(x => x.Collection, opt => opt.Ignore())
           ;

        CreateMap<CollectionSize, CollectionSizeDto>();
        CreateMap<CreateCollectionSizeDto, CollectionSize>()
            .ForMember(x => x.Size, opt => opt.Ignore())
            ;

        CreateMap<UpdateCollectionProductTypeDto, CollectionProductType>()
            .ForMember(x => x.ProductType, opt => opt.Ignore())
            ;


        CreateMap<UpdateCollectionSizeDto, CollectionSize>()
            .ForMember(x => x.Size, opt => opt.Ignore())
            ;

    }
}