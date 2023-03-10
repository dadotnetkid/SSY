using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Products.Collections.Calendars.Dtos;

namespace SSY.Products.Collections.Calendars
{
    public class CalendarApplicationAutoMapperProfile:Profile
    {
        public CalendarApplicationAutoMapperProfile()
        {
            CreateMap<Calendar, CalendarDto>();
            CreateMap<Calendar, CreateCalendarDto>();
            CreateMap<Calendar, UpdateCalendarDto>();
            CreateMap<CreateCalendarDto,Calendar>();
        }
    }
}
