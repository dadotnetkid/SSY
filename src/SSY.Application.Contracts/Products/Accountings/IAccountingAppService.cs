using System;
using SSY.Products.Accountings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SSY.Products.Accountings;

public interface IAccountingAppService : ICrudAppService<AccountingDto, Guid, PagedAndSortedResultRequestDto, CreateAccountingDto, UpdateAccountingDto>
{

}

