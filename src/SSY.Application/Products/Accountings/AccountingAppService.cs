//using Volo.Abp.Application.Services;
//using System;
//using SSY.Products.Accountings.Dto;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.Domain.Repositories;
//using System.Linq;
//using System.Threading.Tasks;
//using SSY.Products.Pricings.Dto;
//using Volo.Abp;

//namespace SSY.Products.Accountings;

//public class AccountingAppService : CrudAppService<Accounting, AccountingDto, Guid, PagedAndSortedResultRequestDto, CreateAccountingDto, UpdateAccountingDto>
//{
//    public AccountingAppService(IRepository<Accounting, Guid> repository) : base(repository)
//    {
//    }

//    protected override async Task<IQueryable<Accounting>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
//    {
//        try
//        {
//            return await base.CreateFilteredQueryAsync(input);
//        }
//        catch (Exception ex)
//        {
//            string innerException = string.Empty;
//            if (ex.InnerException != null)
//                innerException = $"\nInnerException:{ex.InnerException.Message}";

//            throw new UserFriendlyException($"{ex.Message}{innerException}");
//        }
//    }

//    public override Task<AccountingDto> CreateAsync(CreateAccountingDto input)
//    {
//        try
//        {
//            return base.CreateAsync(input);
//        }
//        catch (Exception ex)
//        {
//            string innerException = string.Empty;
//            if (ex.InnerException != null)
//                innerException = $"\nInnerException:{ex.InnerException.Message}";

//            throw new UserFriendlyException($"{ex.Message}{innerException}");
//        }
//    }

//    public override Task<AccountingDto> UpdateAsync(Guid id, UpdateAccountingDto input)
//    {
//        try
//        {
//            return base.UpdateAsync(id, input);
//        }
//        catch (Exception ex)
//        {
//            string innerException = string.Empty;
//            if (ex.InnerException != null)
//                innerException = $"\nInnerException:{ex.InnerException.Message}";

//            throw new UserFriendlyException($"{ex.Message}{innerException}");
//        }
//    }
//}