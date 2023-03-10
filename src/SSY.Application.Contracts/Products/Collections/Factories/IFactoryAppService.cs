using System;
using SSY.Products.Collections.Factories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.Factories;

public interface IFactoryAppService : ICrudAppService<FactoryDto, int, PagedAndSortedResultRequestDto, CreateFactoryDto, UpdateFactoryDto>
{
}