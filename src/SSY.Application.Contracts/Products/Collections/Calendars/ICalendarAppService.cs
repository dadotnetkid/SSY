using SSY.Products.Collections.Calendars.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.Calendars;

public interface ICalendarAppService : ICrudAppService<CalendarDto, Guid, PagedAndSortedResultRequestDto, CreateCalendarDto, UpdateCalendarDto>
{
    public Task<PagedResultDto<GetCalendarCollectionDto>> GetCalendarCollection();
}