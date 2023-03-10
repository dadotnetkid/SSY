using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using SSY.Products.Dtos;
using SSY.Products.Shopifies.Dtos;

namespace SSY.Products;

public interface IProductAppService : ICrudAppService<ProductDto, Guid, GetAllProductDto, CreateProductDto, UpdateProductDto>
{
    Task CreateListAsync(List<CreateProductDto> createProductDtos);
    Task ApproveAsync(ApproveProductDto input);
    Task RejectAsync(ApproveProductDto input);
    Task UpdateOptionsAsync(List<CreateProductOptionDto> options);
    //Task<ShopifyDto> CreateShopifyAsync(CreateShopifyDto input);
    Task<ShopifyDto> UpdateShopifyAsync(UpdateShopifyDto input);
    Task UpdateShopifyListAsync(List<UpdateShopifyDto> inputs);
    Task SetActiveAsync(Guid input);
    Task ResetActiveAsync(Guid input);
    Task DeleteProductsByIds(List<Guid> ids);
}