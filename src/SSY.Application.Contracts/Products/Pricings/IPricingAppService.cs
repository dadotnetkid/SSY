using System;
using SSY.Products.Pricings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Pricings;

public interface IPricingAppService : ICrudAppService<PricingDto, Guid, PagedAndSortedResultRequestDto, CreatePricingDto, UpdatePricingDto>
{
}