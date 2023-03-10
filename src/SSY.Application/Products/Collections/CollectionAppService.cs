using SSY.Products.Collections.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SSY.Products.Collections.ColorOptions;
using System.Collections.Generic;
using SSY.Products.Collections.DesignStatuses;
using SSY.Products.Dtos;
using System.Threading;
using SSY.Products.Collections.ShippingTypes;
using ShopifySharp;
using SSY.Products.Types.Dtos;
using System.Text.Json;
using SSY.Products.Accountings;
using SSY.Products.ApprovalStatuses;
using SSY.Products.CustomFilters;
using SSY.Products.Pricings;
using System.Xml.Linq;
using System.Drawing;
using SSY.Products.Collections.AssignedTos;
using SSY.Products.Collections.AssignedTos.Dtos;
using Volo.Abp.ObjectMapping;
using SSY.Products.Collections.ColorOptions.Dtos;
using System.Drawing.Imaging;
using Volo.Abp.EventBus.Local;
using SSY.Products.Statuses;

namespace SSY.Products.Collections;

public class CollectionAppService : CrudAppService<Collection, CollectionDto, Guid, PagedAndSortedResultRequestDto, CreateCollectionDto, UpdateCollectionDto>
{
    private readonly IRepository<DesignStatus, int> _designStatusRepository;
    private readonly ILocalEventBus _localEventBus;
    private readonly IProductAppService _productAppService;
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<ColorOption, Guid> _colorOptionRepository;
    private readonly IRepository<Products.Statuses.Status, int> _productStatusRepository;
    private readonly IRepository<ApprovalStatus, int> _approvalStatusRepository;
    private readonly IRepository<Collections.Statuses.Status, int> _collectionStatusRepository;
    private readonly IRepository<Products.Sizes.Size, int> _sizeRepository;

    public CollectionAppService(
        IRepository<Products.Sizes.Size, int> sizeRepository,
        IRepository<Collections.Statuses.Status, int> collectionStatusRepository,
        IRepository<ApprovalStatus, int> approvalStatusRepository,
        IRepository<Status, int> productStatusRepository,
        IRepository<ColorOption, Guid> colorOptionRepository,
        IRepository<Product, Guid> productRepository,
        IProductAppService productAppService,
        IRepository<DesignStatus, int> designStatusRepository,
        IRepository<Collection, Guid> repository, ILocalEventBus localEventBus) : base(repository)
    {
        _productAppService = productAppService;
        _designStatusRepository = designStatusRepository;
        _localEventBus = localEventBus;
        _productRepository = productRepository;
        _colorOptionRepository = colorOptionRepository;
        _productStatusRepository = productStatusRepository;
        _approvalStatusRepository = approvalStatusRepository;
        _collectionStatusRepository = collectionStatusRepository;
        _sizeRepository = sizeRepository;
    }

    protected override async Task<IQueryable<Collection>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        try
        {
            return await base.CreateFilteredQueryAsync(input);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    protected override async Task<CollectionDto> MapToGetOutputDtoAsync(Collection entity)
    {
        try
        {
            if (entity.IsDeleted)
            {
                return default;
            }
            var query = await ReadOnlyRepository.GetQueryableAsync();

            var collection = await query.IgnoreQueryFilters()
                .Include(x => x.AssignedTo)
                .Include(x => x.ColorOptions)
                    .ThenInclude(x => x.ProductTypes)
                .Include(x => x.ColorOptions)
                    .ThenInclude(x => x.Fabrics)
                        .ThenInclude(x => x.Rolls)
                .Include(x => x.DesignStatus)
                .Include(x => x.Factory)
                .Include(x => x.MarketingType)
                .Include(x => x.PricePoint)
                .Include(x => x.Season)
                .Include(x => x.ShippingType)
                .Include(x => x.Status)
                .Include(x => x.Influencers)
                .Include(x => x.ProductTypes)
                    .ThenInclude(x => x.ProductType)
                .Include(x => x.Sizes)
                        .ThenInclude(x => x.Size)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Status)
                .Include(x => x.Products)
                    .ThenInclude(x => x.ChildProducts)
                        .ThenInclude(x => x.Status)
                .Include(x => x.Products)
                    .ThenInclude(x => x.ChildProducts)
                        .ThenInclude(x => x.ColorOption)
                .Include(x => x.Products)
                    .ThenInclude(x => x.ColorOption)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            return ObjectMapper.Map<Collection, CollectionDto>(collection);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override async Task<CollectionDto> CreateAsync(CreateCollectionDto input)
    {
        try
        {
            // Creation of Product
            // TODO: Only automatic create product for colorOptions that are not yet used by products.

            var sizes = await _sizeRepository.GetListAsync();

            if (sizes.Any())
                sizes.ForEach(x => input.Sizes.Add(new() { IsActive = true, SizeId = x.Id }));

            input.AssignedTo.IsActive = true;

            var collection = await base.CreateAsync(input);

            var products = await CollectionGenerateParentProduct(collection);

            await _productAppService.CreateListAsync(products);

            return collection;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public override async Task<CollectionDto> UpdateAsync(Guid id, UpdateCollectionDto input)
    {
        try
        {
            var query = await Repository.GetQueryableAsync();

            var entity = await query.IgnoreQueryFilters()
                    .Include(x => x.AssignedTo)
                    .Include(x => x.ProductTypes)
                    .Include(x => x.Influencers)
                    .Include(x => x.Sizes)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.ChildProducts)
                            .ThenInclude(x => x.ColorOption)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.Type)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.ChildProducts)
                            .ThenInclude(x => x.BillOfMaterial)
                    .Include(x => x.ColorOptions)
                        .ThenInclude(x => x.Fabrics)
                            .ThenInclude(x => x.Rolls)
                    .Include(x => x.ColorOptions)
                        .Where(x => x.IsDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == id);

            await MapToEntityAsync(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            int newFabricCount = 0;
            entity.ColorOptions.ToList().ForEach(x => {
                newFabricCount += x.Fabrics.Count();
            });

            if (newFabricCount == input.CurrentFabricCount)
            {
                if (entity.StatusId == 1003)
                    entity.SetProductsIsActive(true);
                else
                    entity.SetProductsIsActive(false);

                await CurrentUnitOfWork.SaveChangesAsync();

                #region Remove Child Products if Color Option is removed

                await RemoveProducts(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                #endregion
            }
            else
            {
                #region Generate for new products

                var collection = await MapToGetOutputDtoAsync(entity);

                var products = await GenerateParentProduct(collection);

                if (products.Count != 0)
                    await _productAppService.CreateListAsync(products);

                #endregion

                if (entity.StatusId == 1003)
                    entity.SetProductsIsActive(true);
                else
                    entity.SetProductsIsActive(false);

                await CurrentUnitOfWork.SaveChangesAsync();

                #region Remove Child Products if Color Option is removed

                await RemoveProducts(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                #endregion
            }

            await CurrentUnitOfWork.SaveChangesAsync();
            return await MapToGetOutputDtoAsync(entity);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private async Task RemoveProducts(Collection entity)
    {
        try
        {
            List<Product> productsToDelete = new();
            List<Product> productsExist = new();
            List<Guid> materialIds = new();

            entity.ColorOptions.ToList().ForEach(colorOption => {
                colorOption.Fabrics.ToList().ForEach(fabric => {
                    if (!materialIds.Contains(fabric.MaterialId))
                        materialIds.Add(fabric.MaterialId);
                });
            });

            if (materialIds.Any())
            {
                materialIds.ForEach(materialId => {
                    var productExisted = entity.Products.ToList().FindAll(x => x.ParentId != null && materialIds.Any(c => c == x.BillOfMaterial.MaterialId));
                    if (productExisted.Any())
                        productExisted.ForEach(x => {
                            if (!productsExist.Contains(x))
                                productsExist.Add(x);
                        });
                });
            }

            entity.Products.Where(x => x.ParentId != null).ToList().ForEach(child => {
                if (!productsExist.Any(x => x.Id == child.Id))
                {
                    if (!productsToDelete.Contains(child))
                        productsToDelete.Add(child);
                }
            });

            productsToDelete.ForEach(child =>
            {
                child.SetIsDeleted(true);
                CurrentUnitOfWork.SaveChangesAsync().Wait();
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

    public override async Task DeleteAsync(Guid id)
    {
        try
        {
            var query = await Repository.GetQueryableAsync();

            var collection = query.Include(x => x.Products)
                .FirstOrDefault(x => x.Id == id);

            if (collection == null)
                throw new UserFriendlyException($"Collection not found.");

            List<Guid> products = new();

            collection.Products.ToList().ForEach(x => products.Add(x.Id));

            await Repository.DeleteAsync(collection.Id);

            await _productAppService.DeleteProductsByIds(products);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateApproveColorOptionAsync(ApproveRejectColorOptionDto input)
    {
        try
        {
            var query = await Repository.GetQueryableAsync();
            var collection = query.Include(x => x.ColorOptions)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.ChildProducts)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.Type)
                    .FirstOrDefault(x => x.Id == input.CollectionId);

            if (collection.ColorOptions.Any(x => x.Id == input.CollectionId))
                throw new UserFriendlyException($"Color Option not found.");

            collection.ApproveColorOption(input.ColorOptionId, input.ApprovedBy);

            await CurrentUnitOfWork.SaveChangesAsync();

            var colorOption = await _colorOptionRepository.FirstOrDefaultAsync(x => x.Id == input.ColorOptionId);

            collection.Products.ToList().ForEach(child => {
                var ch = child;
                if (child.ColorId == colorOption.ColorId && child.Type.MaterialTypeId == colorOption.TypeId)
                {
                    child.SetIsActive(true);
                    child.SetIsDeleted(false);
                    CurrentUnitOfWork.SaveChangesAsync().Wait();
                }
            });

            await CurrentUnitOfWork.SaveChangesAsync();

            var co = collection;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateRejectColorOptionAsync(ApproveRejectColorOptionDto input)
    {
        try
        {
            var query = await Repository.GetQueryableAsync();
            var collection = query.Include(x => x.ColorOptions)
                    .Include(x => x.Products)
                        .ThenInclude(x => x.ChildProducts)
                    .FirstOrDefault(x => x.Id == input.CollectionId);

            if (collection.ColorOptions.Any(x => x.Id == input.CollectionId))
                throw new UserFriendlyException($"Color Option not found.");

            collection.ResetApproval();
            collection.RejectColorOption(input.ColorOptionId, input.ApprovedBy);

            var status = await _collectionStatusRepository.FirstOrDefaultAsync(x => x.Value.Equals("In Progress"));
            collection.SetStatus(status != null ? status.Id : 1001);
            await CurrentUnitOfWork.SaveChangesAsync();

            collection.SetProductsIsActive(false);
            await CurrentUnitOfWork.SaveChangesAsync();

            var colorOption = collection.ColorOptions.FirstOrDefault(x => x.Id == input.ColorOptionId);

            var childproducts = collection.Products.Where(x => x.ParentId.HasValue).ToList();
            childproducts.ForEach(child => {
                if (child.ColorId == colorOption.ColorId)
                {
                    child.SetIsDeleted(true);
                    CurrentUnitOfWork.SaveChangesAsync().Wait();
                }
            });

            collection.RemoveColorOption(colorOption);
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

    public async Task UpdatePublishCollection(Guid collectionId)
    {
        try
        {
            var collection = await Repository.GetAsync(collectionId);

            if (collection == null)
                throw new UserFriendlyException($"Collection not found.");

            collection.SetPublish();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task UpdateResetApprovalAsync(Guid collectionId)
    {
        try
        {
            var query = await Repository.GetQueryableAsync();
            var collection = query.Include(x => x.ColorOptions)
                    .FirstOrDefault(x => x.Id == collectionId);

            collection.ResetApproval();
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<List<CollectionTimelineDto>> GetCollectionTimeline()
    {
        try
        {
            var designStatus = await _designStatusRepository.GetListAsync(c => c.IsActive && c.Id <= 11001);

            List<string> notIncludedStatus = new();

            notIncludedStatus.Add("Design Concept Uploaded");
            notIncludedStatus.Add("Design Concept Approved");
            notIncludedStatus.Add("Design Concept Rejected");
            notIncludedStatus.Add("Redrop Preparation");
            notIncludedStatus.Add("Redrop Launch Ready");
            notIncludedStatus.Add("Redrop Launch Date");

            List<CollectionTimelineDto> collectionTimelineList = new();

            foreach (var i in designStatus)
            {
                if (!notIncludedStatus.Any(x => x == i.Value))
                {
                    var collectionByDesignStatus = (Repository.GetListAsync(c => c.IsActive && c.DesignStatusId == i.Id).Result);
                    List<CollectionTimelineItemDto> collectionTimelineItems = new();
                    collectionByDesignStatus.ForEach(c =>
                    {
                        var collectionTime = MapToGetOutputDtoAsync(c).Result.Influencers.Select(i => new CollectionTimelineItemDto()
                        {
                            Id = c.Id,
                            InfluencerName = i.InfluencerFullName,
                            CollectionName = c.Name
                        }).ToList();

                        collectionTime.ForEach(x => { if (collectionTimelineItems.Find(z => z.Id == x.Id) == null) collectionTimelineItems.Add(x); });
                    });

                    collectionTimelineList.Add(new()
                    {
                        Id = i.Id,
                        Name = i.Value,
                        CollectionTimelineList = collectionTimelineItems,
                        Count = collectionByDesignStatus.Count(),
                        CollectionTimelineListCount = collectionTimelineItems.Count()
                    });
                }

            }

            return collectionTimelineList;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<GetAllCollectionListDto> GetCollectionListAsync()
    {
        GetAllCollectionListDto results = new();

        var query = await Repository.GetQueryableAsync();

        var collections = query.IgnoreQueryFilters()
                .Include(x => x.Influencers)
                .Include(x => x.DesignStatus)
                .Include(x => x.Status)
                .Include(x => x.Products)
                    .ThenInclude(x => x.ChildProducts);

        List<CollectionListDto> collectionList = new();

        collections.Where(x => x.IsActive == true && x.IsDeleted == false).OrderByDescending(x => x.CreationTime).ToList().ForEach(x =>
        {

            var collection = MapToGetOutputDtoAsync(x);

            List<CollectionColorOptionDto> colorOptions = new();

            collection.Result.ColorOptions.ForEach(c => colorOptions.Add(new() { ColorOptionId = c.Id, CollectionId = c.CollectionId, Fabrics = c.Fabrics }));

            List<string> infuencers = new();
            List<Guid> infuencerIds = new();

            x.Influencers.ToList().ForEach(i =>
            {
                infuencers.Add(i.InfluencerFullName);
                infuencerIds.Add(i.InfluencerId);
            });

            collectionList.Add(new()
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                InfluencerNames = string.Join(", ", infuencers),
                InfluencerIds = infuencerIds,
                DesignStatusValue = x.DesignStatus.Value,
                ParentProductCount = x.Products.Where(x => x.IsActive == true && x.IsDeleted == false && x.ParentId == null).Count(),
                ChildProductCount = x.Products.Where(x => x.IsActive == true && x.IsDeleted == false && x.ParentId != null).Count(),
                DevelopmentStartDate = x.CreationTime,
                ProvisionalLaunchDate = x.ProvisionalLaunchDate,
                StatusValue = x.Status.Value,
                Availability = x.Availability,
                ColorOptions = colorOptions
            });

        });

        results.TotalCount = collectionList.Count;
        results.Items = collectionList;

        return results;
    }

    private async Task<List<CreateProductDto>> CollectionGenerateParentProduct(CollectionDto input)
    {
        try
        {
            List<CreateProductDto> parentProducts = new();

            var products = (await _productAppService.GetListAsync(new() { IsActive = true, MaxResultCount = 1 }));
            var productStatus = (await _productStatusRepository.FirstOrDefaultAsync(x => x.Value.Equals("Product Onboarded")));
            var approvalStatus = (await _approvalStatusRepository.FirstOrDefaultAsync(x => x.Value.Equals("Pending")));

            List<ProductDto> childProductDto = new();
            products.Items.ToList().ForEach(x =>
            {
                if (x != null)
                    x.ChildProducts.ForEach(c => childProductDto.Add(x));
            });

            // Creation of Parent Products
            input.ProductTypes.ForEach(async productType =>
            {

                double shippingPremium = 0;
                var shippingValue = input.ShippingType;

                if (shippingValue.Value.Equals("Free Shipping (FedEx)"))
                    shippingPremium = productType.ProductType.FreeShippingFedExPrice.Value;
                else if (shippingValue.Value.Equals("Free Shipping (DHL)"))
                    shippingPremium = productType.ProductType.FreeShippingDHLPrice.Value;
                else if (shippingValue.Value.Equals("10 USD Shipping"))
                    shippingPremium = productType.ProductType.TenUSDPrice.Value;
                else if (shippingValue.Value.Equals("15 USD Shipping"))
                    shippingPremium = productType.ProductType.FifteenUSDPrice.Value;
                else if (shippingValue.Value.Equals("20 USD Shipping"))
                    shippingPremium = productType.ProductType.TwentyUSDPrice.Value;
                else
                    shippingPremium = 0;

                CreateProductDto parent = new();

                var prodType = input.ProductTypes.FirstOrDefault(x => x.ProductType.Id == productType.ProductType.Id);

                parent.IsActive = input.Status.Id == 1003 ? true : false;
                parent.Sku = await GenerateParentSKU(input, prodType, products.TotalCount);
                parent.Name = $"{input.Name.Replace(" Collection", "")} {productType.ProductType.Value}";
                parent.TypeId = productType.ProductType.Id;
                parent.StatusId = productStatus.Id;
                parent.CollectionId = input.Id;
                parent.ApprovalStatusId = approvalStatus.Id;
                parent.Pricing = new()
                {
                    IsActive = true,
                    ShippingPremium = (int)shippingPremium
                };
                parent.Accounting = new()
                {
                    IsActive = true,
                };

                // Creation of Child Products
                List<CreateProductDto> childProductsDto = new();

                input.ColorOptions.Where(x => x.ProductTypes.Any(p => p.ProductTypeId == productType.ProductType.Id)).ToList().ForEach(async colorOption =>
                {
                    var childProducts = childProductDto.Select(x => x.ColorId).ToList();
                    var childProductCount = childProducts.FindAll(x => x == colorOption.ColorId).Count;
                    int childskuCount = childProductCount;
                    colorOption.Fabrics.ForEach(async fabric => {

                        CreateProductDto child = new();

                        child.IsActive = input.Status.Id == 1003 ? true : false;
                        child.Name = $"{colorOption.ColorValue} {productType.ProductType.Value}";
                        child.Sku = await GenerateChildParentSKU(parent.Sku, colorOption.ColorShortCode, childskuCount);
                        child.TypeId = productType.ProductType.Id;
                        child.StatusId = productStatus.Id;
                        child.CollectionId = input.Id;
                        child.ApprovalStatusId = approvalStatus.Id;
                        child.ColorOptionId = colorOption.Id;
                        child.ColorId = colorOption.ColorId;
                        child.ColorValue = colorOption.ColorValue;
                        child.ColorShortCode = colorOption.ColorShortCode;
                        child.Shopify = new()
                        {
                            IsActive = true,
                            Name = child.Name,
                            Price = shippingPremium,
                            FabricComposition = fabric.FabricComposition,
                            CareInstruction = fabric.CareInstruction
                        };
                        child.BillOfMaterial = new()
                        {
                            IsActive = true,
                            PartNumber = 10,
                            PartName = $"Main Body",
                            ColorCode = fabric.ColorCode,
                            ItemCode = fabric.ItemCode,
                            MaterialId = fabric.MaterialId,
                            Consumption = productType.ProductType.AverageConsumption,
                            UnitOfMeasurement = fabric.UnitOfMeasurement,
                            CuttableWidth = fabric.CuttableWidth,
                            ContentDescription = fabric.ContentDescription,
                            Price = fabric.Price,
                            Supplier = fabric.Supplier
                        };

                        childProductsDto.Add(child);
                        childskuCount++;
                    });

                });

                parent.ChildProducts = childProductsDto;

                parentProducts.Add(parent);

            });

            return parentProducts;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private async Task<List<CreateProductDto>> GenerateParentProduct(CollectionDto input)
    {
        try
        {
            List<CreateProductDto> parentProducts = new();

            var productQuery = await _productRepository.GetQueryableAsync();

            var products = productQuery.IgnoreQueryFilters()
                            .Include(x => x.ChildProducts)
                            .Where(x => x.IsActive && !x.IsDeleted)
                            .ToList();

            var productStatus = (await _productStatusRepository.FirstOrDefaultAsync(x => x.Value.Equals("Product Onboarded")));
            var approvalStatus = (await _approvalStatusRepository.FirstOrDefaultAsync(x => x.Value.Equals("Pending")));

            List<ProductDto> childProductDto = new();
            products.ForEach(x =>
            {
                if (x != null)
                    x.ChildProducts.ToList().ForEach(c => childProductDto.Add(ObjectMapper.Map<Product, ProductDto>(x)));
            });

            // Creation of Parent Products
            input.ProductTypes.ForEach(async productType =>
            {
                double shippingPremium = 0;
                var shippingValue = input.ShippingType;

                if (shippingValue.Value.Equals("Free Shipping (FedEx)"))
                    shippingPremium = productType.ProductType.FreeShippingFedExPrice.Value;
                else if (shippingValue.Value.Equals("Free Shipping (DHL)"))
                    shippingPremium = productType.ProductType.FreeShippingDHLPrice.Value;
                else if (shippingValue.Value.Equals("10 USD Shipping"))
                    shippingPremium = productType.ProductType.TenUSDPrice.Value;
                else if (shippingValue.Value.Equals("15 USD Shipping"))
                    shippingPremium = productType.ProductType.FifteenUSDPrice.Value;
                else if (shippingValue.Value.Equals("20 USD Shipping"))
                    shippingPremium = productType.ProductType.TwentyUSDPrice.Value;
                else
                    shippingPremium = 0;

                var parentProduct = input.Products.Find(x => x.ParentId == null && x.TypeMaterialTypeId == productType.ProductType.MaterialTypeId && x.TypeId == productType.ProductType.Id);

                if (parentProduct == null)
                {
                    CreateProductDto parent = new();

                    var prodType = input.ProductTypes.FirstOrDefault(x => x.ProductType.Id == productType.ProductType.Id);

                    parent.IsActive = input.Status.Id == 1003 ? true : false;
                    parent.Sku = await GenerateParentSKU(input, prodType, products.Count);
                    parent.Name = $"{input.Name.Replace(" Collection", "")} {productType.ProductType.Value}";
                    parent.TypeId = productType.ProductType.Id;
                    parent.StatusId = productStatus.Id;
                    parent.CollectionId = input.Id;
                    parent.ApprovalStatusId = approvalStatus.Id;
                    parent.Pricing = new()
                    {
                        IsActive = true,
                        ShippingPremium = (int)shippingPremium
                    };
                    parent.Accounting = new()
                    {
                        IsActive = true,
                    };

                    // Creation of Child Products
                    List<CreateProductDto> childProductsDto = new();

                    input.ColorOptions.Where(x => x.ProductTypes.Any(p => p.ProductTypeId == productType.ProductType.Id)).ToList().ForEach(async colorOption =>
                    {
                        var childProducts = childProductDto.Select(x => x.ColorId).ToList();
                        var childProductCount = childProducts.FindAll(x => x == colorOption.ColorId).Count;
                        int childskuCount = childProductCount;
                        colorOption.Fabrics.ForEach(async fabric => {

                            CreateProductDto child = new();

                            child.IsActive = input.Status.Id == 1003 ? true : false;
                            child.Name = $"{colorOption.ColorValue} {productType.ProductType.Value}";
                            child.Sku = await GenerateChildParentSKU(parent.Sku, colorOption.ColorShortCode, childskuCount);
                            child.TypeId = productType.ProductType.Id;
                            child.StatusId = productStatus.Id;
                            child.CollectionId = input.Id;
                            child.ApprovalStatusId = approvalStatus.Id;
                            child.ColorOptionId = colorOption.Id;
                            child.ColorId = colorOption.ColorId;
                            child.ColorValue = colorOption.ColorValue;
                            child.ColorShortCode = colorOption.ColorShortCode;
                            child.Shopify = new()
                            {
                                IsActive = true,
                                Name = child.Name,
                                Price = shippingPremium,
                                FabricComposition = fabric.FabricComposition,
                                CareInstruction = fabric.CareInstruction
                            };
                            child.BillOfMaterial = new()
                            {
                                IsActive = true,
                                PartNumber = 10,
                                PartName = $"Main Body",
                                ColorCode = fabric.ColorCode,
                                ItemCode = fabric.ItemCode,
                                MaterialId = fabric.MaterialId,
                                Consumption = productType.ProductType.AverageConsumption,
                                UnitOfMeasurement = fabric.UnitOfMeasurement,
                                CuttableWidth = fabric.CuttableWidth,
                                ContentDescription = fabric.ContentDescription,
                                Price = fabric.Price,
                                Supplier = fabric.Supplier
                            };

                            childProductsDto.Add(child);
                            childskuCount++;
                        });
                    });

                    parent.ChildProducts = childProductsDto;

                    parentProducts.Add(parent);
                }
                else
                {
                    input.ColorOptions.Where(x => x.ProductTypes.Any(p => p.ProductTypeId == productType.ProductType.Id)).ToList().ForEach(async colorOption =>
                    {
                        var childProduct = parentProduct.ChildProducts.Find(x => x.TypeId == productType.ProductType.Id && x.ColorId == colorOption.ColorId);

                        if (childProduct == null)
                        {
                            var childProducts = childProductDto.Select(x => x.ColorId).ToList();
                            var childProductCount = childProducts.FindAll(x => x == colorOption.ColorId).Count;
                            int childskuCount = childProductCount;
                            colorOption.Fabrics.ForEach(async fabric => {

                                CreateProductDto child = new();

                                child.IsActive = input.Status.Id == 1003 ? true : false;
                                child.Name = $"{colorOption.ColorValue} {productType.ProductType.Value}";
                                child.Sku = await GenerateChildParentSKU(parentProduct.Sku, colorOption.ColorShortCode, childskuCount);
                                child.TypeId = productType.ProductType.Id;
                                child.StatusId = productStatus.Id;
                                child.CollectionId = input.Id;
                                child.ApprovalStatusId = approvalStatus.Id;
                                child.ColorOptionId = colorOption.Id;
                                child.ColorId = colorOption.ColorId;
                                child.ColorValue = colorOption.ColorValue;
                                child.ColorShortCode = colorOption.ColorShortCode;
                                child.Shopify = new()
                                {
                                    IsActive = true,
                                    Name = child.Name,
                                    Price = shippingPremium,
                                    FabricComposition = fabric.FabricComposition,
                                    CareInstruction = fabric.CareInstruction
                                };
                                child.BillOfMaterial = new()
                                {
                                    IsActive = true,
                                    PartNumber = 10,
                                    PartName = $"Main Body",
                                    ColorCode = fabric.ColorCode,
                                    ItemCode = fabric.ItemCode,
                                    MaterialId = fabric.MaterialId,
                                    Consumption = productType.ProductType.AverageConsumption,
                                    UnitOfMeasurement = fabric.UnitOfMeasurement,
                                    CuttableWidth = fabric.CuttableWidth,
                                    ContentDescription = fabric.ContentDescription,
                                    Price = fabric.Price,
                                    Supplier = fabric.Supplier
                                };
                                child.ParentId = parentProduct.Id;

                                parentProducts.Add(child);
                                childskuCount++;
                            });
                        }
                    });
                }

            });

            return parentProducts;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private async Task<string> GenerateParentSKU(CollectionDto collection, CollectionProductTypeDto productTypeDto, long productTotalCount)
    {
        try
        {
            List<string> parentSKU = new();

            #region Influencers

            List<string> influencers = new();
            if (collection.Influencers.Count == 1)
            {
                collection.Influencers.ForEach(x =>
                {
                    influencers.Add($"{x.InfluencerName[0]}{x.InfluencerSurname[0]}");
                });
            }
            else
            {
                collection.Influencers.ForEach(x =>
                {
                    influencers.Add($"{x.InfluencerName[0]}");
                });
            }

            var name = ReplaceString(JsonSerializer.Serialize(influencers)).Replace(" ", "");
            parentSKU.Add(name);

            #endregion

            #region 4 Digit Iteration

            var productCount = (productTotalCount + 1).ToString().PadLeft(4, '0');

            parentSKU.Add(productCount);

            #endregion

            #region Season

            string season = collection.Season.Label;

            parentSKU.Add(season);

            #endregion

            #region Year

            string year = collection.Year.ToString();

            parentSKU.Add(year);

            #endregion

            #region Material Type

            var materialType = productTypeDto.MaterialTypeShortCode;

            parentSKU.Add(materialType);

            #endregion

            #region Product Type

            var productType = productTypeDto.ProductType.ShortCode;

            parentSKU.Add(productType);

            #endregion

            #region 2 Digit Iteration

            var productLastCount = (productTotalCount + 1).ToString().PadLeft(2, '0');

            parentSKU.Add(productLastCount);

            #endregion

            var sku = JsonSerializer.Serialize(parentSKU).Replace("[", "").Replace("]", "").Replace(",", "").Replace("\"", "");

            return sku;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private async Task<string> GenerateChildParentSKU(string parentSKU, string colorShortCode, long childProductTotalCount)
    {
        try
        {
            List<string> childSKU = new();

            #region Parent SKU

            childSKU.Add(parentSKU);

            #endregion

            childSKU.Add("-");

            #region Colorway

            childSKU.Add(colorShortCode);

            #endregion

            #region Iteration

            var iteration = (childProductTotalCount + 1).ToString().PadLeft(2, '0');

            childSKU.Add(iteration);

            #endregion

            var sku = JsonSerializer.Serialize(childSKU).Replace("[", "").Replace("]", "").Replace(",", "").Replace("\"", "");

            return sku;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    private string ReplaceString(string input)
    {
        return input.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", ", ").Replace("\\u0022", "''");
    }

}