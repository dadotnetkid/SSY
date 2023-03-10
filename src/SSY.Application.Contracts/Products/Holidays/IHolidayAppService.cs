using System;
using SSY.Products.Holidays.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Holidays;

public interface IHolidayAppService: ICrudAppService< HolidayDto, long, PagedAndSortedResultRequestDto, CreateHolidayDto, UpdateHolidayDto>
{
}