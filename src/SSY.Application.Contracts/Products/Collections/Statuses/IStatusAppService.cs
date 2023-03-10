using System;
using SSY.Products.Collections.Statuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.Statuses;

public interface IStatusAppService : ICrudAppService<StatusDto, int, PagedAndSortedResultRequestDto, CreateStatusDto, UpdateStatusDto>
{
}