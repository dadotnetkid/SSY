using AutoMapper;
using SSY.Products.Holidays.Dtos;

namespace SSY.Products.Holidays;

public class HolidayApplicationAutoMapperProfile : Profile
{
    public HolidayApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Holiday, HolidayDto>();
        CreateMap<CreateHolidayDto, Holiday>();
        CreateMap<UpdateHolidayDto, Holiday>();
    }
}