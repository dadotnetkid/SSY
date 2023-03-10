using System.Linq;
using AutoMapper;
using SSY.Products.Dtos;

namespace SSY.Products;

public class ProductsApplicationAutoMapperProfile : Profile
{
    public ProductsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>()
            .ForMember(x => x.Type, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.Ignore())
            .ForMember(x => x.LaunchCategory, opt => opt.Ignore())
            .ForMember(x => x.Options, opt => opt.Ignore())
            .ForMember(x => x.ProductMediaFiles, opt => opt.Ignore())
            .ForMember(x => x.RejectionNotes, opt => opt.Ignore())
            .ForMember(x => x.ChildProducts, opt => opt.Ignore())
            .ForMember(x => x.ColorOption, opt => opt.Ignore())
            ;
        CreateMap<UpdateProductDto, Product>()
            .ForMember(x => x.Type, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.Ignore())
            .ForMember(x => x.LaunchCategory, opt => opt.Ignore())
            .ForMember(x => x.Options, opt => opt.Ignore())
            .ForMember(x => x.ProductMediaFiles, opt => opt.Ignore())
            .ForMember(x => x.RejectionNotes, opt => opt.Ignore())
            .ForMember(x => x.ChildProducts, opt => opt.Ignore())
            .ForMember(x => x.Shopify, opt => opt.Ignore())
            .ForMember(x => x.ColorOption, opt => opt.Ignore())
            ;

        CreateMap<ProductMediaFile, ProductMediaFileDto>();
        CreateMap<UpdateProductMediaFileDto, ProductMediaFile>()
            .ForMember(x => x.MediaFile, opt => opt.Ignore())
            ;

        CreateMap<ProductOption, ProductOptionDto>();
        CreateMap<CreateProductOptionDto, ProductOption>();
        CreateMap<UpdateProductOptionDto, ProductOption>();
    }
}