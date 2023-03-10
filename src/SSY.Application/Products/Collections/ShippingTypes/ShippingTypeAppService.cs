using System;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.Seasons;
using SSY.Products.Collections.Seasons.Dtos;
using SSY.Products.Collections.ShippingTypes.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.ShippingTypes;

public class ShippingTypeAppService : CrudAppService<ShippingType, ShippingTypeDto, int, PagedAndSortedResultRequestDto, CreateShippingTypeDto, UpdateShippingTypeDto>, IShippingTypeAppService
{
    public ShippingTypeAppService(IRepository<ShippingType, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<ShippingType>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<ShippingTypeDto> CreateAsync(CreateShippingTypeDto input)
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

    public override Task<ShippingTypeDto> UpdateAsync(int id, UpdateShippingTypeDto input)
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