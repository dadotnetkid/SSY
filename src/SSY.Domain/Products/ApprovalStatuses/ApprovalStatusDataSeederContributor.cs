using System;
using System.Threading.Tasks;
using SSY.Products.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.ApprovalStatuses;

public class ApprovalStatusDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ApprovalStatus, int> _approvalStatusRepository;

    public ApprovalStatusDataSeederContributor(IRepository<ApprovalStatus, int> approvalStatusRepository)
    {
        _approvalStatusRepository = approvalStatusRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _approvalStatusRepository.GetCountAsync() <= 0)
        {
            await _approvalStatusRepository.InsertAsync(new ApprovalStatus(1001, "Pending", "Pending", 1), autoSave: true);
            await _approvalStatusRepository.InsertAsync(new ApprovalStatus(1002, "Approved", "Approved", 2), autoSave: true);
            await _approvalStatusRepository.InsertAsync(new ApprovalStatus(1003, "Changes Required", "Changes Required", 3), autoSave: true);
            await _approvalStatusRepository.InsertAsync(new ApprovalStatus(1004, "Rejected", "Rejected", 4), autoSave: true);
        }
    }
}