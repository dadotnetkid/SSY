using Volo.Abp.Application.Services;
using SSY.Products.Collections.DesignStatuses.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.DesignStatuses;

public interface IDesignStatusAppService : ICrudAppService<DesignStatusDto, int, PagedAndSortedResultRequestDto, CreateDesignStatusDto, UpdateDesignStatusDto>
{
}