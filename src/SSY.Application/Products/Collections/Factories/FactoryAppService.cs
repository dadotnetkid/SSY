using System;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.Factories.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Collections.Factories;

public class FactoryAppService : CrudAppService<Factory, FactoryDto, int, PagedAndSortedResultRequestDto, CreateFactoryDto, UpdateFactoryDto>, IFactoryAppService
{
    public FactoryAppService(IRepository<Factory, int> repository)
       : base(repository)
    {
    }

    protected override async Task<IQueryable<Factory>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<FactoryDto> CreateAsync(CreateFactoryDto input)
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

    public override Task<FactoryDto> UpdateAsync(int id, UpdateFactoryDto input)
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