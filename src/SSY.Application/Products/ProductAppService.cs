using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using SSY.Products.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using SSY.Products.Shopifies;
using SSY.Products.Shopifies.Dtos;
using SSY.Products.RejectionNotes;
using SSY.Products.RejectionNotes.Dtos;

namespace SSY.Products;

public class ProductAppService :
    CrudAppService<
        Product,
        ProductDto,
        Guid,
        GetAllProductDto,
        CreateProductDto,
        UpdateProductDto>,
    IProductAppService
{
    public readonly IGuidGenerator _guidGenerator;
    public IRepository<ProductOption> _productOptionRepository;
    public IRepository<ProductMediaFile> _productMediaFileRepository;
    public IRepository<Shopify, Guid> _shopifyRepository;
    public IRepository<ShopifyMediaFile> _shopifyMediaFileRepository;

    public ProductAppService(
        IGuidGenerator guidGenerator,
        IRepository<ProductOption> productOptionRepository,
        IRepository<ProductMediaFile> productMediaFileRepository,
        IRepository<Shopify, Guid> shopifyRepository,
        IRepository<ShopifyMediaFile> shopifyMediaFileRepository,
        IRepository<Product, Guid> repository) : base(repository)
    {
        _guidGenerator = guidGenerator;
        _productOptionRepository = productOptionRepository;
        _productMediaFileRepository = productMediaFileRepository;
        _shopifyRepository = shopifyRepository;
        _shopifyMediaFileRepository = shopifyMediaFileRepository;
    }

    #region Override Methods

    protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(GetAllProductDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            return query.IgnoreQueryFilters()
                .Where(x => x.ParentId == null)
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    protected override async Task<ProductDto> MapToGetOutputDtoAsync(Product entity)
    {
        try
        {
            if (entity.IsDeleted)
            {
                return default;
            }
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == entity.Id)
                .Where(x => x.ParentId == null)
                .Include(x => x.Type)
                .Include(x => x.Status)
                .Include(x => x.Options)
                .Include(x => x.ColorOption)
                .Include(x => x.ProductMediaFiles)
                    .ThenInclude(x => x.MediaFile)
                .Include(x => x.RejectionNotes)
                        .ThenInclude(x => x.MediaFiles)
                            .ThenInclude(x => x.MediaFile)
                .Include(x => x.Shopify)
                    .ThenInclude(x => x.MediaFiles)
                        .ThenInclude(x => x.MediaFile)
                .Include(x => x.Accounting)
                .Include(x => x.Pricing)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.Type)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.Status)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.Options)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.ProductMediaFiles)
                        .ThenInclude(x => x.MediaFile)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.RejectionNotes)
                        .ThenInclude(x => x.MediaFiles)
                            .ThenInclude(x => x.MediaFile)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.Shopify)
                        .ThenInclude(x => x.MediaFiles)
                            .ThenInclude(x => x.MediaFile)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.BillOfMaterial)
                .Include(x => x.ChildProducts)
                    .ThenInclude(x => x.ColorOption)
                .Include(x => x.Collection)
                    .ThenInclude(x => x.Influencers)
                .Include(x => x.Collection)
                    .ThenInclude(x => x.Factory)
                .FirstOrDefault();

            return ObjectMapper.Map<Product, ProductDto>(product);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override async Task<ProductDto> GetAsync(Guid id)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return await MapToGetOutputDtoAsync(product);
            //return await base.GetAsync(id);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override async Task<ProductDto> CreateAsync(CreateProductDto input)
    {
        try
        {
            await CheckCreatePolicyAsync();

            // Checking if status = 1 isactive = false;

            //input.IsActive = input.ApprovalStatusId == 1003 || input.ApprovalStatusId == 1004 ? false : true;

            var product = await MapToEntityAsync(input);
            await Repository.InsertAsync(product, autoSave: true);
            await CurrentUnitOfWork.SaveChangesAsync();

            input.ChildProducts?.ForEach(x =>
            {
                var childProduct = MapToEntityAsync(x).Result;
                childProduct.SetParentId(product.Id);

                Repository.InsertAsync(childProduct, autoSave: true).Wait();
                CurrentUnitOfWork.SaveChangesAsync().Wait();
            });

            await CurrentUnitOfWork.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(product);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
    {
        try
        {
            await CheckUpdatePolicyAsync();
            var productQuery = await ReadOnlyRepository.GetQueryableAsync();
            var productMediaFileQuery = await _productMediaFileRepository.GetQueryableAsync();

            // Product
            var product = productQuery.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);

            ObjectMapper.Map(input, product);

            await CurrentUnitOfWork.SaveChangesAsync();

            if (input.ProductMediaFiles.Any())
            {
                var mediaFiles = productMediaFileQuery.IgnoreQueryFilters().Where(x => x.ProductId == product.Id);
                await _productMediaFileRepository.DeleteManyAsync(mediaFiles, autoSave: true);
                await CurrentUnitOfWork.SaveChangesAsync();
            };

            input.ProductMediaFiles?.ForEach(x =>
            {
                var mediaFile = ObjectMapper.Map<UpdateProductMediaFileDto, ProductMediaFile>(x);
                mediaFile.SetProductId(product.Id);
                product.AddProductionFile(mediaFile);

                CurrentUnitOfWork.SaveChangesAsync().Wait();
            });

            input.ChildProducts?.ForEach(x =>
            {
                x.ParentId = product.Id;

                if (x.Id != Guid.Empty)
                {
                    var childProduct = productQuery.IgnoreQueryFilters()
                        .Include(x => x.BillOfMaterial)
                        .Include(x => x.Pricing)
                        .Include(x => x.Accounting)
                        .FirstOrDefault(c => c.Id == x.Id);

                    ObjectMapper.Map(x, childProduct);
                    CurrentUnitOfWork.SaveChangesAsync().Wait();

                    if (x.ProductMediaFiles.Any())
                    {
                        var mediaFiles = productMediaFileQuery.IgnoreQueryFilters().Where(x => x.ProductId == childProduct.Id);
                        _productMediaFileRepository.DeleteManyAsync(mediaFiles, autoSave: true).Wait();
                        CurrentUnitOfWork.SaveChangesAsync().Wait();
                    };

                    x.ProductMediaFiles?.ForEach(x =>
                    {
                        var mediaFile = ObjectMapper.Map<UpdateProductMediaFileDto, ProductMediaFile>(x);
                        mediaFile.SetProductId(childProduct.Id);
                        childProduct.AddProductionFile(mediaFile);

                        CurrentUnitOfWork.SaveChangesAsync().Wait();
                    });
                }
                else
                {
                    var childProduct = Repository.InsertAsync(ObjectMapper.Map<UpdateProductDto, Product>(x), autoSave: true).Result;

                    x.ProductMediaFiles?.ForEach(x =>
                    {
                        var mediaFile = ObjectMapper.Map<UpdateProductMediaFileDto, ProductMediaFile>(x);
                        mediaFile.SetProductId(childProduct.Id);
                        childProduct.AddProductionFile(mediaFile);
                    });
                }

                CurrentUnitOfWork.SaveChangesAsync().Wait();
            });

            return await MapToGetOutputDtoAsync(product);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    #endregion

    #region Other Methods

    public async Task CreateListAsync(List<CreateProductDto> createProductDtos)
    {
        try
        {
            createProductDtos.ForEach(x => CreateAsync(x).Wait());
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task ApproveAsync(ApproveProductDto input)
    {
        try
        {
            var products = await Repository.GetQueryableAsync();
            input.ProductIds.ForEach(id =>
            {
                var product = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
                product.Approve();

                if (product.ParentId.HasValue)
                {
                    var parentProduct = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == product.ParentId.Value);
                    parentProduct.Approve();
                }
            });
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task SetActiveAsync(Guid input)
    {
        try
        {
            var products = await Repository.GetQueryableAsync();

            var product = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == input);
            product.SetIsActive(true);

            if (product.ParentId.HasValue)
            {
                var parentProduct = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == product.ParentId.Value);
                parentProduct.SetIsActive(true);
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task ResetActiveAsync(Guid input)
    {
        try
        {
            var products = await Repository.GetQueryableAsync();

            var product = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == input);
            product.SetIsActive(false);

            if (product.ParentId.HasValue)
            {
                var parentProduct = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == product.ParentId.Value);
                parentProduct.SetIsActive(false);
            }
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task RejectAsync(ApproveProductDto input)
    {
        try
        {
            var products = await Repository.GetQueryableAsync();
            input.ProductIds.ForEach(id =>
            {
                var product = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
                product.Reject();

                if (product.ParentId.HasValue)
                {
                    var parentProduct = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == product.ParentId.Value);

                    if (!parentProduct.ChildProducts.Any(x => x.IsActive))
                    {
                        parentProduct.Reject();
                    }
                }
            });
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task RejectChildAsync(ApproveProductDto input)
    {
        try
        {
            var products = await Repository.GetQueryableAsync();
            input.ProductIds.ForEach(id =>
            {
                var product = products.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
                product.Reject();
            });
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateOptionsAsync(List<CreateProductOptionDto> options)
    {
        try
        {
            var groupedProductOptions = options.GroupBy(x => x.ProductId).ToList();

            var products = await Repository.GetQueryableAsync();

            groupedProductOptions.ForEach(p =>
            {
                var productOptions = p.ToList();
                var productId = productOptions.FirstOrDefault()?.ProductId;

                var product = products.IgnoreQueryFilters()
                                .Include(x => x.Options)
                                .FirstOrDefault(x => x.Id == productId);

                var productOptionsList = ObjectMapper.Map<List<CreateProductOptionDto>, List<ProductOption>>(productOptions);

                product.AddOptions(productOptionsList);
            });

            await CurrentUnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private async Task<ShopifyDto> CreateShopifyAsync(CreateShopifyDto input)
    {
        try
        {
            var entity = ObjectMapper.Map<CreateShopifyDto, Shopify>(input);
            await _shopifyRepository.InsertAsync(entity, autoSave: true);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Shopify, ShopifyDto>(entity);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<ShopifyDto> UpdateShopifyAsync(UpdateShopifyDto input)
    {
        try
        {
            var entity = ObjectMapper.Map<UpdateShopifyDto, Shopify>(input);
            await _shopifyRepository.UpdateAsync(entity, autoSave: true);
            await CurrentUnitOfWork.SaveChangesAsync();

            var query = await _shopifyMediaFileRepository.GetQueryableAsync();
            var mediaFiles = query.IgnoreQueryFilters().Where(x => x.ShopifyId == entity.Id);

            await _shopifyMediaFileRepository.DeleteManyAsync(mediaFiles, autoSave: true);
            await CurrentUnitOfWork.SaveChangesAsync();

            input.MediaFiles.ForEach(x =>
            {
                var mediaFile = ObjectMapper.Map<UpdateShopifyMediaFileDto, ShopifyMediaFile>(x);
                mediaFile.SetShopifyId(entity.Id);

                _shopifyMediaFileRepository.InsertAsync(mediaFile, autoSave: true).Wait();
                CurrentUnitOfWork.SaveChangesAsync().Wait();
            });

            entity = await _shopifyRepository.GetAsync(input.Id);

            return ObjectMapper.Map<Shopify, ShopifyDto>(entity);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateShopifyListAsync(List<UpdateShopifyDto> inputs)
    {
        try
        {
            inputs.ForEach(async input =>
            {
                var entity = ObjectMapper.Map<UpdateShopifyDto, Shopify>(input);
                _shopifyRepository.UpdateAsync(entity, autoSave: true).Wait();
                CurrentUnitOfWork.SaveChangesAsync().Wait();

                var query = await _shopifyMediaFileRepository.GetQueryableAsync();
                var mediaFiles = query.IgnoreQueryFilters().Where(x => x.ShopifyId == entity.Id);

                _shopifyMediaFileRepository.DeleteManyAsync(mediaFiles, autoSave: true).Wait();
                CurrentUnitOfWork.SaveChangesAsync().Wait();

                input.MediaFiles.ForEach(x =>
                {
                    var mediaFile = ObjectMapper.Map<UpdateShopifyMediaFileDto, ShopifyMediaFile>(x);
                    mediaFile.SetShopifyId(entity.Id);

                    _shopifyMediaFileRepository.InsertAsync(mediaFile, autoSave: true).Wait();
                    CurrentUnitOfWork.SaveChangesAsync().Wait();
                });

                //entity = _shopifyRepository.GetAsync(input.Id).Wait();
            });

            //return ObjectMapper.Map<Shopify, ShopifyDto>(entity);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateInternalApproveMediaFileCategoryAsync(ApproveMediaFileCatgoryDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == input.ProductId)
                .Include(x => x.ProductMediaFiles)
                    .ThenInclude(x => x.MediaFile)
                .FirstOrDefault();

            product.InternalApproveMediaFileCategory(input.MediaFileCategoryId, input.ApprovedBy);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateInternalRejectMediaFileCategoryAsync(CreateRejectionNoteDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == input.ProductId)
                .Include(x => x.ProductMediaFiles)
                    .ThenInclude(x => x.MediaFile)
                .FirstOrDefault();

            product.RejectMediaFileCategory(input.MediaFileCategoryId);
            await UpdateRejectionNoteAsync(input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateInfluencerApproveMediaFileCategoryAsync(ApproveMediaFileCatgoryDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == input.ProductId)
                .Include(x => x.ProductMediaFiles)
                    .ThenInclude(x => x.MediaFile)
                .FirstOrDefault();

            product.InfluencerApproveMediaFileCategory(input.MediaFileCategoryId, input.ApprovedBy);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateInfluencerRejectMediaFileCategoryAsync(CreateRejectionNoteDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == input.ProductId)
                .Include(x => x.ProductMediaFiles)
                    .ThenInclude(x => x.MediaFile)
                .FirstOrDefault();

            product.RejectMediaFileCategory(input.MediaFileCategoryId);
            await UpdateRejectionNoteAsync(input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateRejectionNoteAsync(CreateRejectionNoteDto input)
    {
        try
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();

            var product = query.IgnoreQueryFilters()
                .Where(x => x.Id == input.ProductId)
                .Include(x => x.RejectionNotes)
                .FirstOrDefault();

            product.AddRejectionNote(ObjectMapper.Map<CreateRejectionNoteDto, RejectionNote>(input));
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task DeleteProductsByIds(List<Guid> ids)
    {
        try
        {
            await Repository.DeleteManyAsync(ids);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<PagedResultDto<object>> GetProducts(ProductRequestDto dto)
    {

        try
        {
            var query = await Repository.GetQueryableAsync();

            if (!string.IsNullOrEmpty(dto.IncludedProperties))
            {
                foreach (var i in dto.IncludedProperties.Split(","))
                {
                    query = query.Include(i);
                }
            }
            IQueryable result = query;
            if (!string.IsNullOrEmpty(dto.Fields))
            {
                result = query.Select(dto.Fields);
            }

            return new PagedResultDto<object>()
            {
                Items = result.ToDynamicList(),
                TotalCount = result.Count()
            };
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<GetAllProductListDto> GetProductListAsync()
    {
        GetAllProductListDto results = new();

        var query = await Repository.GetQueryableAsync();

        var products = query.IgnoreQueryFilters()
                .Include(x => x.Status)
                .Include(x => x.Collection)
                    .ThenInclude(x => x.Influencers);

        List<ProductListDto> productLists = new();

        products.Where(x => x.IsActive == true && x.ParentId == null && x.IsDeleted == false).OrderByDescending(x => x.CreationTime).ToList().ForEach(x =>
        {

            List<string> infuencers = new();

            x.Collection.Influencers.ToList().ForEach(i => infuencers.Add(i.InfluencerFullName));

            productLists.Add(new()
            {
                Id = x.Id,
                Name = x.Name,
                DesignStatusValue = x.Status.Value,
                CollectioName = x.Collection.Name,
                InfluencerNames = string.Join(", ", infuencers),
                Sku = x.Sku,
                CreationTime = x.CreationTime
            });
        });

        results.TotalCount = productLists.Count;
        results.Items = productLists;

        return results;
    }

    private string ReplaceString(string input)
    {
        return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
    }

    #endregion
}