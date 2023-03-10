using System;
using SSY.Products.ApprovalStatuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.ApprovalStatuses;

public interface IApprovalStatusAppService : ICrudAppService<ApprovalStatusDto, int, PagedAndSortedResultRequestDto, CreateApprovalStatusDto, UpdateApprovalStatusDto>
{
}