using System;
using SSY.Products.Collections.Factories;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.DesignStatuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace SSY.Products.Collections.DesignStatuses;

public class DesignStatusAppService : CrudAppService<DesignStatus, DesignStatusDto, int, PagedAndSortedResultRequestDto, CreateDesignStatusDto, UpdateDesignStatusDto>, IDesignStatusAppService
{
    public DesignStatusAppService(IRepository<DesignStatus, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<DesignStatus>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<DesignStatusDto> CreateAsync(CreateDesignStatusDto input)
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

    public override Task<DesignStatusDto> UpdateAsync(int id, UpdateDesignStatusDto input)
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