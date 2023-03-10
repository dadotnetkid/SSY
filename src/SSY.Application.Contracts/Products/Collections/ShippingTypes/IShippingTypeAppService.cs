using System;
using SSY.Products.Collections.ShippingTypes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.ShippingTypes;

public interface IShippingTypeAppService : ICrudAppService<ShippingTypeDto, int, PagedAndSortedResultRequestDto, CreateShippingTypeDto, UpdateShippingTypeDto>
{
}