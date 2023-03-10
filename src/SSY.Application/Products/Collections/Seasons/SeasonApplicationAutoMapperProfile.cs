using AutoMapper;
using SSY.Products.Collections.Seasons.Dtos;

namespace SSY.Products.Collections.Seasons;

public class SeasonApplicationAutoMapperProfile : Profile
{
    public SeasonApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Season, SeasonDto>().ReverseMap();
        CreateMap<CreateSeasonDto, Season>().ReverseMap();
        CreateMap<UpdateSeasonDto, Season>().ReverseMap();
    }
}