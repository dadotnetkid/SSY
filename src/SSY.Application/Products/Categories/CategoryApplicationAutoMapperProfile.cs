using AutoMapper;
using SSY.Products.Categories.Dtos;

namespace SSY.Products.Categories;

public class CategoryApplicationAutoMapperProfile : Profile
{
    public CategoryApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}