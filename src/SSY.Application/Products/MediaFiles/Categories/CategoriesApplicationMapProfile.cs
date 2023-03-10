using AutoMapper;
using SSY.Products.MediaFiles.Categories.Dtos;

namespace SSY.Products.MediaFiles.Categories;

public class MediaFileApplicationMapProfile : Profile
{
    public MediaFileApplicationMapProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}