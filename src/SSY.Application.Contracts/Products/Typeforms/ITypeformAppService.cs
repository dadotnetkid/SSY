using System;
using SSY.Products.Typeforms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Typeforms;

public interface ITypeformAppService : ICrudAppService<TypeformDto, Guid, PagedAndSortedResultRequestDto, CreateTypeformDto, UpdateTypeformDto>
{
}