using Volo.Abp.Application.Services;
using System;
using SSY.Products.Collections.Drops.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Drops;

public interface IDropAppService : ICrudAppService<DropDto, int, PagedAndSortedResultRequestDto, CreateDropDto, UpdateDropDto>
{
}