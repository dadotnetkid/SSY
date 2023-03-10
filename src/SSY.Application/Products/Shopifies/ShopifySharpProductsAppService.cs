using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using ShopifySharp;
using ShopifySharp.Filters;
using ShopifySharp.Lists;
using Microsoft.EntityFrameworkCore;
using SSY.Products.Shopifies.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.EventBus.Local;

namespace SSY.Products.Shopifies;

public partial class ShopifyAppService : ApplicationService, IShopifyAppService
{
    private readonly ILocalEventBus _localEventBus;

    public ShopifyAppService(ILocalEventBus localEventBus)
    {
        _localEventBus = localEventBus;
    }
    #region Shopify App

    private static readonly string myShopifyUrl = "https://sewsewyou-beta-1.myshopify.com/admin/api/2022-10/";
    private static readonly string shopAccessToken = "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";

    #region Collects - A Collect is an object that connects a product to a custom collection.

    /// <summary>
    /// Creating a collect
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Collect> CreateCollectAsync(Collect input)
    {

        try
        {
            var service = new CollectService(myShopifyUrl, shopAccessToken);
            var collect = await service.CreateAsync(input);

            return collect;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    /// <summary>
    /// Retrieving a collect
    /// </summary>
    /// <param name="collectId"></param>
    /// <returns></returns>
    public async Task<Collect> GetCollectAsync(long collectId)
    {
        var service = new CollectService(myShopifyUrl, shopAccessToken);
        // 30967151788075
        var collect = await service.GetAsync(collectId);

        return collect;
    }

    /// <summary>
    /// Deleting a collect
    /// </summary>
    /// <param name="collectId"></param>
    /// <returns></returns>
    public async Task DeleteCollectAsync(long collectId)
    {
        var service = new CollectService(myShopifyUrl, shopAccessToken);

        await service.DeleteAsync(collectId);
    }

    /// <summary>
    /// Counting collects
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<int> GetCollectCountAsync(CollectCountFilter input)
    {
        var service = new CollectService(myShopifyUrl, shopAccessToken);
        //int collectCount = await service.CountAsync();

        //Optionally filter the count to only those collects for a certain product or collection
        int filteredCollectCount = await service.CountAsync(input);

        return filteredCollectCount;
    }

    /// <summary>
    /// Listing collects
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ListResult<Collect>> GetCollectListAsync(CollectListFilter input)
    {
        var service = new CollectService(myShopifyUrl, shopAccessToken);
        // var collects = await service.ListAsync();

        //Optionally filter the list to only those collects for a certain product or collection
        var filteredCollects = await service.ListAsync(input);

        return filteredCollects;
    }

    #endregion

    #region Collections - API version 2020-01 introduces the new "Collections" endpoint, which can be used to get the base details and list of products associated with either a Custom Collection or Smart Collection. This endpoint cannot be used to manipulate the products, collects, custom collections or smart collections.You must use the entity's respective ShopifySharp service to do that (i.e. CollectService, ProductService, CustomCollectionService and SmartCollectionService).

    /// <summary>
    /// Getting a Collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    public async Task GetCollectionAsync(long collectionId)
    {
        var service = new CollectionService(myShopifyUrl, shopAccessToken);
        var collection = await service.GetAsync(collectionId);
    }

    /// <summary>
    /// Listing products belonging to a Collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    public async Task<ListResult<ShopifySharp.Product>> GetCollectionListProductsAsync(long collectionId)
    {
        var service = new CollectionService(myShopifyUrl, shopAccessToken);
        var products = await service.ListProductsAsync(collectionId);

        return products;
    }

    #endregion

    #region Custom Collections - A custom collection is a grouping of products that a shop owner can create to make their shops easier to browse. A shop owner creates a custom collection and then selects the products that will go into it.

    /// <summary>
    /// Creating a custom collection
    /// If published = true, published_At = hasDate
    /// If published = false, published_At = null
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CustomCollection> CreateCustomCollectionAsync(CustomCollection input, Guid collectionId)
    {

        try
        {
            var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);

            // TODO:  Create a Custom Collection per Collection (SSY) when Creating Material Plan ( published = false)
            //TODO: Params title, published (put online)

            var collection = await service.CreateAsync(input);
            await _localEventBus.PublishAsync(new ShopifyOnPublishCollectionEvent()
            {
                ShopifyId = collection.Id,
                CollectionId = collectionId,
                PublishedAt = collection.PublishedAt,
                Name = collection.Title,
            });
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

    /// <summary>
    /// Getting a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    public async Task<CustomCollection> GetCustomCollectionAsync(long collectionId)
    {
        // Test Data: Collection Id
        //collectionId = 275569606699;

        var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);
        var collection = await service.GetAsync(collectionId);

        return collection;
    }

    /// <summary>
    /// Counting custom collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<int> GetCustomCollectionCountAsync(CustomCollectionCountFilter input)
    {
        var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);
        var count = await service.CountAsync(input);

        return count;
    }

    /// <summary>
    /// Listing custom collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ListResult<CustomCollection>> GetCustomCollectionListAsync(CustomCollectionListFilter input)
    {
        var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);
        var collections = await service.ListAsync(input);

        return collections;
    }

    /// <summary>
    /// Updating a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CustomCollection> UpdateCustomCollectionAsync(long collectionId, CustomCollection input)
    {
        var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);
        var collection = await service.UpdateAsync(collectionId, input);

        return collection;
    }

    /// <summary>
    /// Deleting a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    public async Task DeleteCustomCollectionAsync(long collectionId)
    {
        var service = new CustomCollectionService(myShopifyUrl, shopAccessToken);

        await service.DeleteAsync(collectionId);
    }

    #endregion

    #region Products

    /// <summary>
    /// Creating a product
    /// </summary>
    /// <param name="input"></param>
    /// <param name="productId"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task<ShopifySharp.Product> CreateProductAsync(ShopifySharp.Product input, Guid productId)
    {

        try
        {
            var service = new ProductService(myShopifyUrl, shopAccessToken);

            // CHILD PRODUCT
            //        {
            //            "id": 0, // ShopifyNumber
            //  "title": "string", // name
            //  "bodyHtml": "string", // description
            //  "vendor": "string", // influencerVendorName
            //  "productType": "string", // productType
            //  "handle": "string", // sku
            //  "tags": "string", // tags
            //  "variants": [
            //    {
            //      "sku": "string", // childProductSku
            //      "weight": 0, // (to be discuss with jhun)weight 
            //    }]
            //}

            var product = await service.CreateAsync(input);

            //By default, creating a product will publish it. To create an unpublished product:+1:
            //product = await service.CreateAsync(input, new ProductCreateOptions() { Published = false });

            //this event trigger for the shopify that there is a publish product in the shopify
            await _localEventBus.PublishAsync(new ShopifyOnPublishEvent()
            {
                ShopifyId = product.Id,
                ProductId = productId,
                PublishedAt = product.PublishedAt,
                Name = product.Title,
                VariantId = product.Variants.FirstOrDefault().Id
            });
            return product;
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";
            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    /// <summary>
    /// Retrieving a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ShopifySharp.Product> GetProductAsync(long productId)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        // Test Data productId 7036809150507
        // productId = 7036809183275;

        var product = await service.GetAsync(productId);

        return product;
    }

    /// <summary>
    /// Updating a product
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ShopifySharp.Product> UpdateProductAsync(long productId, ShopifySharp.Product input)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        var product = await service.UpdateAsync(productId, input);

        return product;
    }

    /// <summary>
    /// Deleting a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task DeleteProductAsync(long productId)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);

        await service.DeleteAsync(productId);
    }

    /// <summary>
    /// Counting products
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<int> GetProductCountAsync(ProductCountFilter input)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        int productCount = await service.CountAsync(input);

        return productCount;
    }

    /// <summary>
    /// Listing products
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ListResult<ShopifySharp.Product>> GetProductListAsync(ProductListFilter input)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        var products = await service.ListAsync(input);

        return products;
    }

    /// <summary>
    /// Publishing a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ShopifySharp.Product> UpdateProductPublishAsync(long productId)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        var product = await service.PublishAsync(productId);

        return product;
    }

    /// <summary>
    /// Unpublishing a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ShopifySharp.Product> UpdateProductUnpublishAsync(long productId)
    {
        var service = new ProductService(myShopifyUrl, shopAccessToken);
        var product = await service.UnpublishAsync(productId);

        return product;
    }

    #endregion

    #region Product Images - Product Images represent the various different images for a product. All product images are tied to an owner product, and therefore you'll need to pass that product's id to each product image method.

    /// <summary>
    /// Creating a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ProductImage> CreateProductImageAsync(long productId, ProductImage input)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);
        var image = await service.CreateAsync(productId, input);

        return image;
    }

    /// <summary>
    /// Getting a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    public async Task<ProductImage> GetProductImageAsync(long productId, long imageId)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);
        var image = await service.GetAsync(productId, imageId);

        return image;
    }

    /// <summary>
    /// Counting product images
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<int> GetProductImageCountAsync(long productId)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);
        var count = await service.CountAsync(productId);

        return count;
    }

    /// <summary>
    /// Listing product images
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ListResult<ProductImage>> GetProductImageListAsync(long productId)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);
        var images = await service.ListAsync(productId);

        return images;
    }

    /// <summary>
    /// Updating a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ProductImage> UpdateProductImageAsync(long productId, long imageId, ProductImage input)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);
        var image = await service.UpdateAsync(productId, imageId, input);

        return image;
    }

    /// <summary>
    /// Deleting a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    public async Task DeleteProductImageAsync(long productId, long imageId)
    {
        var service = new ProductImageService(myShopifyUrl, shopAccessToken);

        await service.DeleteAsync(productId, imageId);
    }

    #endregion

    #region Product Variants - A product variant is a different version of a product, such as differing sizes or differing colors. Without product variants, you would have to treat the small, medium and large versions of a t-shirt as three separate products; product variants let you treat the small, medium and large versions of a t-shirt as variations of the same product.

    // Product-ColorOption

    #endregion

    #region Smart Collections - A smart collection is a grouping of products defined by simple rules set by shop owners. A shop owner creates a smart collection and then sets the rules that determine which products go in them. Shopify automatically changes the contents of smart collections based on their rules.

    /// <summary>
    /// Creating a Smart Collection
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<SmartCollection> CreateSmartCollection(SmartCollection input)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);
        var smartCollection = await service.CreateAsync(input);

        return smartCollection;
    }

    /// <summary>
    /// Updating a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<SmartCollection> UpdateSmartCollectionAsync(long smartCollectionId, SmartCollection input)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);
        var smartCollection = await service.UpdateAsync(smartCollectionId, input);

        return smartCollection;
    }

    /// <summary>
    /// Getting a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <returns></returns>
    public async Task<SmartCollection> GetSmartCollectionAsync(long smartCollectionId)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);
        var smartCollection = await service.GetAsync(smartCollectionId);

        return smartCollection;
    }

    /// <summary>
    /// Counting Smart Collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<int> GetSmartCollectionCountAsync(SmartCollectionCountFilter input)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);
        var count = await service.CountAsync(input);

        return count;
    }

    /// <summary>
    /// Listing Smart Collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ListResult<SmartCollection>> GetSmartCollectionListAsync(SmartCollectionListFilter input)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);
        var smartCollections = await service.ListAsync(input);

        return smartCollections;
    }

    /// <summary>
    /// Deleting a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <returns></returns>
    public async Task DeleteSmartCollectionAsync(long smartCollectionId)
    {
        var service = new SmartCollectionService(myShopifyUrl, shopAccessToken);

        await service.DeleteAsync(smartCollectionId);
    }

    #endregion

    #endregion
}