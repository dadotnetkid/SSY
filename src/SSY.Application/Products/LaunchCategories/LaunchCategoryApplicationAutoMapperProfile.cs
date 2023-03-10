using AutoMapper;
using SSY.Products.LaunchCategories.Dtos;

namespace SSY.Products.LaunchCategories;

public class LaunchCategoryApplicationAutoMapperProfile : Profile
{
    public LaunchCategoryApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<LaunchCategory, LaunchCategoryDto>();
        CreateMap<CreateLaunchCategoryDto, LaunchCategory>();
        CreateMap<UpdateLaunchCategoryDto, LaunchCategory>();
    }
}
