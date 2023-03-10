using System;
using SSY.Products.MediaFiles.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.MediaFiles.Categories;

public interface ICategoryAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, CreateCategoryDto, UpdateCategoryDto>
{
}