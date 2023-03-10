//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using SSY.Products.Pricings.Dto;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.Application.Services;
//using Volo.Abp.Domain.Repositories;
//using Volo.Abp;
//using Volo.Abp.Guids;
//using SSY.Products.Shopifies;

//namespace SSY.Products.Pricings;

//public class PricingAppService : CrudAppService<Pricing, PricingDto, Guid, PagedAndSortedResultRequestDto, CreatePricingDto, UpdatePricingDto>, IPricingAppService
//{
//    public PricingAppService(
//       IRepository<Pricing, Guid> repository)
//       : base(repository)
//    {
//    }


//    protected override async Task<IQueryable<Pricing>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

//    public override Task<PricingDto> CreateAsync(CreatePricingDto input)
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

//    public override Task<PricingDto> UpdateAsync(Guid id, UpdatePricingDto input)
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