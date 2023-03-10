using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using SSY.Products.Collections.CalendarConfigurations.Dtos;

namespace SSY.Products.Collections.CalendarConfigurations;

public interface ICalendarConfigurationsAppService : ICrudAppService<CalendarConfigurationDto, int, PagedAndSortedResultRequestDto, CreateCalendarConfigurationDto, UpdateCalendarConfigurationDto>
{
}