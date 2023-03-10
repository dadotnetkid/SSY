using SSY.Products.Collections.Calendars.Dtos;
using System;
using System.Threading.Tasks;
using SSY.Products.Collections.CalendarDetails.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.CalendarDetails;

public interface ICalendarDetailsAppService : ICrudAppService<CalendarDetailDto, Guid, PagedAndSortedResultRequestDto, CreateCalendarDetailDto, UpdateCalendarDetailDto>
{
    Task UpdateCalendarStatus(Guid collectionId, int designStatusId);
}