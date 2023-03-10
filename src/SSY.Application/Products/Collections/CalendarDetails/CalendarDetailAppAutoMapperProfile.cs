using AutoMapper;
using SSY.Products.Collections.CalendarDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Products.Collections.CalendarDetails
{
    public class CalendarDetailAppAutoMapperProfile : Profile
    {
        public CalendarDetailAppAutoMapperProfile()
        {
            CreateMap<CalendarDetail, CalendarDetailDto>();
            CreateMap<CalendarDetail, CreateCalendarDetailDto>();

            CreateMap< CreateCalendarDetailDto, CalendarDetail>();
            CreateMap<CalendarDetail, UpdateCalendarDetailDto>();
        }
    }
}
