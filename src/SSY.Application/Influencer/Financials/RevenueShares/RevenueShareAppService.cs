using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSY.Enums;
using SSY.Influencer.Financials.RevenueShares.Dto;
using SSY.Influencers.RevenueShares;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Financials.RevenueShares;

public class RevenueShareAppService : CrudAppService<RevenueShare, RevenueShareDto, Guid, PagedAndSortedResultRequestDto, CreateRevenueShareDto, UpdateRevenueShareDto>, IRevenueShareAppService
{
    public RevenueShareAppService(IRepository<RevenueShare, Guid> repository) : base(repository)
    {
    }

    public async Task<List<RevenueShareDto>> GetListByUserId(Guid userId)
    {
        var qry = await Repository.GetQueryableAsync();
        var list = qry.Where(c => c.UserId == userId).ToList();

        var res = ObjectMapper.Map<List<RevenueShare>, List<RevenueShareDto>>(list);
        if (!res.Any())
        {
            if (!res.Any())
            {
                res.AddRange(new List<RevenueShareDto>()
                {
                    new ()
                    {
                        RevenueShareType = RevenueShareType.Personal
                    },
                    new()
                    {
                        RevenueShareType = RevenueShareType.Agent
                    }
                });
            }
        }
        return res;
    }
}