using System;
using SSY.Products.LaunchCategories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.LaunchCategories;

public interface ILaunchCategoryAppService : ICrudAppService<LaunchCategoryDto, int, PagedAndSortedResultRequestDto, CreateLaunchCategoryDto, UpdateLaunchCategoryDto>
{
}