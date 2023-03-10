using System;
using SSY.Products.Sizes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Sizes;

public interface ISizeAppService : ICrudAppService<SizeDto, int, PagedAndSortedResultRequestDto, CreateSizeDto, UpdateSizeDto>
{
}