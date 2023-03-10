using System;
using SSY.Products.Statuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Statuses;

public interface IStatusAppService : ICrudAppService<StatusDto, int, PagedAndSortedResultRequestDto, CreateStatusDto, UpdateStatusDto>
{
}