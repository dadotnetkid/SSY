using System;
using SSY.Products.Collections.Factories;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.MarketingTypes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace SSY.Products.Collections.MarketingTypes;

public class MarketingTypeAppService : CrudAppService<MarketingType, MarketingTypeDto, int, PagedAndSortedResultRequestDto, CreateMarketingTypeDto, UpdateMarketingTypeDto>, IMarketingTypeAppService
{
    public MarketingTypeAppService(IRepository<MarketingType, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<MarketingType>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        try
        {
            return await base.CreateFilteredQueryAsync(input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override Task<MarketingTypeDto> CreateAsync(CreateMarketingTypeDto input)
    {
        try
        {
            return base.CreateAsync(input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override Task<MarketingTypeDto> UpdateAsync(int id, UpdateMarketingTypeDto input)
    {
        try
        {
            return base.UpdateAsync(id, input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }
}