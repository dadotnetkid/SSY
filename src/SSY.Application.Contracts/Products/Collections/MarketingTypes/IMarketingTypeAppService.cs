using SSY.Products.Collections.MarketingTypes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Collections.MarketingTypes;

public interface IMarketingTypeAppService : ICrudAppService<MarketingTypeDto, int, PagedAndSortedResultRequestDto, CreateMarketingTypeDto, UpdateMarketingTypeDto>
{
}