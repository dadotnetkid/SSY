using System;
using SSY.Products.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Categories;

public interface ICategoryAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, CreateCategoryDto, UpdateCategoryDto>
{
}