using System;
using SSY.Products.Types.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Types;

public interface ITypeAppService : ICrudAppService<TypeDto, int, PagedAndSortedResultRequestDto, CreateTypeDto, UpdateTypeDto>
{
}