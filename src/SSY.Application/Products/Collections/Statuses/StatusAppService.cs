using System;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.Seasons;
using SSY.Products.Collections.ShippingTypes.Dtos;
using SSY.Products.Collections.Statuses.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Statuses;

public class CollectionStatusAppService : CrudAppService<Status, StatusDto, int, PagedAndSortedResultRequestDto, CreateStatusDto, UpdateStatusDto>, IStatusAppService
{
    public CollectionStatusAppService(IRepository<Status, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<Status>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<StatusDto> CreateAsync(CreateStatusDto input)
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

    public override Task<StatusDto> UpdateAsync(int id, UpdateStatusDto input)
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