using AutoMapper;
using SSY.Products.Shopifies.Dtos;

namespace SSY.Products.Shopifies;

public class ShopifyApplicationAutoMapperProfile : Profile
{
    public ShopifyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Shopify, ShopifyDto>();
        CreateMap<CreateShopifyDto, Shopify>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            .ForMember(x => x.MediaFiles, opt => opt.Ignore())
            ;
        CreateMap<UpdateShopifyDto, Shopify>()
            .ForMember(x => x.Product, opt => opt.Ignore())
            .ForMember(x => x.MediaFiles, opt => opt.Ignore())
            ;
        CreateMap<UpdateShopifyDto, CreateShopifyDto>();

        CreateMap<ShopifyMediaFile, ShopifyMediaFileDto>();
        CreateMap<CreateShopifyMediaFileDto, ShopifyMediaFile>()
            .ForMember(x => x.MediaFile, opt => opt.Ignore())
            ;
        CreateMap<UpdateShopifyMediaFileDto, ShopifyMediaFile>()
            .ForMember(x => x.MediaFile, opt => opt.Ignore())
            ;
    }
}