using Volo.Abp.Application.Services;
using System;
using SSY.Products.Collections.Seasons.Dtos;
using Volo.Abp.Application.Dtos;
using SSY.Products.Collections.PricePoints;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.PricePoints.Dtos;
using Volo.Abp;

namespace SSY.Products.Collections.Seasons;

public class SeasonAppService : CrudAppService<Season, SeasonDto, int, PagedAndSortedResultRequestDto, CreateSeasonDto, UpdateSeasonDto>, ISeasonAppService
{
    public SeasonAppService(IRepository<Season, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<Season>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<SeasonDto> CreateAsync(CreateSeasonDto input)
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

    public override async Task<SeasonDto> UpdateAsync(int id, UpdateSeasonDto input)
    {
        try
        {
            return await base.UpdateAsync(id, input);
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