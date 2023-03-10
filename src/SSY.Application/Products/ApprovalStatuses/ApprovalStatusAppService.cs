using System;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.ApprovalStatuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace SSY.Products.ApprovalStatuses;

public class ApprovalStatusAppService : CrudAppService<ApprovalStatus, ApprovalStatusDto, int, PagedAndSortedResultRequestDto, CreateApprovalStatusDto, UpdateApprovalStatusDto>, IApprovalStatusAppService
{
    public ApprovalStatusAppService(IRepository<ApprovalStatus, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<ApprovalStatus>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

    public override Task<ApprovalStatusDto> CreateAsync(CreateApprovalStatusDto input)
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

    public override Task<ApprovalStatusDto> UpdateAsync(int id, UpdateApprovalStatusDto input)
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