using SSY.Influencer.Financials.Banks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Influencer.Financials.Banks
{
    public interface IBankAppService : ICrudAppService<BankDto, Guid, PagedAndSortedResultRequestDto, CreateBankDto, UpdateBankDto>
    {
        Task<BankDto> GetByUserId(Guid userId);
    }
}
