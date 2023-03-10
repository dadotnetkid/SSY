using System;
using SSY.Products.Collections.PricePoints.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.PricePoints;

public interface IPricePointAppService : ICrudAppService<PricePointDto, int, PagedAndSortedResultRequestDto, CreatePricePointDto, UpdatePricePointDto>
{
}