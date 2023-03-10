using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.Influencer.Financials.Banks.Dto;
using SSY.Influencers.Banks;

namespace SSY.Influencer.Financials.Banks
{
    public class BankAppService : CrudAppService<Bank, BankDto, Guid, PagedAndSortedResultRequestDto, CreateBankDto, UpdateBankDto>, IBankAppService
    {
        public BankAppService(IRepository<Bank, Guid> repository) : base(repository)
        {
        }

        public async Task<BankDto> GetByUserId(Guid userId)
        {
            var qry = await Repository.GetQueryableAsync();
            var res = qry.FirstOrDefault(c => c.UserId == userId);
            return await MapToGetOutputDtoAsync(res);
        }
    }
}
