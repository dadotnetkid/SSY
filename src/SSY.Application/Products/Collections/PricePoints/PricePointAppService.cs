using System;
using SSY.Products.Collections.Factories;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.PricePoints.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace SSY.Products.Collections.PricePoints;

public class PricePointAppService : CrudAppService<PricePoint, PricePointDto, int, PagedAndSortedResultRequestDto, CreatePricePointDto, UpdatePricePointDto>, IPricePointAppService
{
    public PricePointAppService(IRepository<PricePoint, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<PricePoint>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<PricePointDto> CreateAsync(CreatePricePointDto input)
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

    public override Task<PricePointDto> UpdateAsync(int id, UpdatePricePointDto input)
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