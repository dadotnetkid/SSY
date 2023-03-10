using System;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Sizes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace SSY.Products.Sizes;

public class SizeAppService : CrudAppService<Size, SizeDto, int, PagedAndSortedResultRequestDto, CreateSizeDto, UpdateSizeDto>, ISizeAppService
{
    public SizeAppService(IRepository<Size, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<Size>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<SizeDto> CreateAsync(CreateSizeDto input)
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

    public override Task<SizeDto> UpdateAsync(int id, UpdateSizeDto input)
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