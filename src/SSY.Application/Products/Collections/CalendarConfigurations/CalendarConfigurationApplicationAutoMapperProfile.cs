using AutoMapper;
using SSY.Products.Collections.CalendarConfigurations.Dtos;

namespace SSY.Products.Collections.CalendarConfigurations;

public class CalendarConfigurationApplicationAutoMapperProfile : Profile
{
    public CalendarConfigurationApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CalendarConfiguration, CalendarConfigurationDto>();
        CreateMap<CreateCalendarConfigurationDto, CalendarConfiguration>()
            .ForMember(x => x.ProductStatus, opt => opt.Ignore());
        CreateMap<UpdateCalendarConfigurationDto, CalendarConfiguration>()
            .ForMember(x => x.ProductStatus, opt => opt.Ignore());
    }
}