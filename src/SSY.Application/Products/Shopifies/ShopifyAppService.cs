//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Runtime.Intrinsics.X86;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using ShopifySharp;
//using SSY.Products.Shopifies.Dto;
//using Volo.Abp;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.Application.Services;
//using Volo.Abp.Domain.Repositories;
//using Volo.Abp.Guids;

//namespace SSY.Products.Shopifies;

//public partial class ShopifyAppService : CrudAppService<Shopify, ShopifyDto, Guid, PagedAndSortedResultRequestDto, CreateShopifyDto, UpdateShopifyDto>, IShopifyAppService
//{
//    public ShopifyAppService(
//        IRepository<Shopify, Guid> repository) : base(repository)
//    {
//    }

//    protected override async Task<IQueryable<Shopify>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
//    {
//        try
//        {
//            var query = await base.CreateFilteredQueryAsync(input);

//            return query.Include(x => x.MediaFiles);
//        }
//        catch (Exception ex)
//        {
//            string innerException = string.Empty;
//            if (ex.InnerException != null)
//                innerException = $"\nInnerException:{ex.InnerException.Message}";

//            throw new UserFriendlyException($"{ex.Message}{innerException}");
//        }
//    }

//    protected async override Task<ShopifyDto> MapToGetOutputDtoAsync(Shopify entity)
//    {
//        try
//        {
//            var query = await ReadOnlyRepository.GetQueryableAsync();

//            var shopify = query.Where(x => x.Id == entity.Id).Include(x => x.MediaFiles).FirstOrDefault();

//            return ObjectMapper.Map<Shopify, ShopifyDto>(shopify);
//        }
//        catch (Exception ex)
//        {
//            string innerException = string.Empty;
//            if (ex.InnerException != null)
//                innerException = $"\nInnerException:{ex.InnerException.Message}";

//            throw new UserFriendlyException($"{ex.Message}{innerException}");
//        }
//    }

//    public override Task<ShopifyDto> CreateAsync(CreateShopifyDto input)
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

//    public override async Task<ShopifyDto> UpdateAsync(Guid id, UpdateShopifyDto input)
//    {
//        try
//        {
//            var entity = await Repository.GetAsync(id);
//            entity.ClearMediaFiles();

//            MapToEntity(input, entity);

//            return MapToGetOutputDto(entity);
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