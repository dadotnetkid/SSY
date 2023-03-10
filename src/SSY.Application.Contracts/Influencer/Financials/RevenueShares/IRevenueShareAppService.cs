using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSY.Influencer.Financials.RevenueShares.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Financials.RevenueShares;

public interface IRevenueShareAppService : ICrudAppService<RevenueShareDto, Guid, PagedAndSortedResultRequestDto, CreateRevenueShareDto, UpdateRevenueShareDto>
{
    Task<List<RevenueShareDto>> GetListByUserId(Guid userId);
}