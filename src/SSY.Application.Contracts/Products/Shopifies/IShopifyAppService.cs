using System;
using System.Threading.Tasks;
using ShopifySharp;
using ShopifySharp.Filters;
using ShopifySharp.Lists;
using Volo.Abp.Application.Services;

namespace SSY.Products.Shopifies;

public interface IShopifyAppService : IApplicationService
{
    /// <summary>
    /// Creating a collect
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<Collect> CreateCollectAsync(Collect input);

    /// <summary>
    /// Retrieving a collect
    /// </summary>
    /// <param name="collectId"></param>
    /// <returns></returns>
    Task<Collect> GetCollectAsync(long collectId);

    /// <summary>
    /// Deleting a collect
    /// </summary>
    /// <param name="collectId"></param>
    /// <returns></returns>
    Task DeleteCollectAsync(long collectId);

    /// <summary>
    /// Counting collects
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<int> GetCollectCountAsync(CollectCountFilter input);

    /// <summary>
    /// Listing collects
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ListResult<Collect>> GetCollectListAsync(CollectListFilter input);

    /// <summary>
    /// Getting a Collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    Task GetCollectionAsync(long collectionId);

    /// <summary>
    /// Listing products belonging to a Collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    Task<ListResult<ShopifySharp.Product>> GetCollectionListProductsAsync(long collectionId);

    /// <summary>
    /// Creating a custom collection
    /// If published = true, published_At = hasDate
    /// If published = false, published_At = null
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<CustomCollection> CreateCustomCollectionAsync(CustomCollection input, Guid collectionId);

    /// <summary>
    /// Getting a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    Task<CustomCollection> GetCustomCollectionAsync(long collectionId);

    /// <summary>
    /// Counting custom collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<int> GetCustomCollectionCountAsync(CustomCollectionCountFilter input);

    /// <summary>
    /// Listing custom collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ListResult<CustomCollection>> GetCustomCollectionListAsync(CustomCollectionListFilter input);

    /// <summary>
    /// Updating a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<CustomCollection> UpdateCustomCollectionAsync(long collectionId, CustomCollection input);

    /// <summary>
    /// Deleting a custom collection
    /// </summary>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    Task DeleteCustomCollectionAsync(long collectionId);

    /// <summary>
    /// Creating a product
    /// </summary>
    /// <param name="input"></param>
    /// <param name="productId"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<Product> CreateProductAsync(Product input, Guid productId);

    /// <summary>
    /// Retrieving a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<ShopifySharp.Product> GetProductAsync(long productId);

    /// <summary>
    /// Updating a product
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ShopifySharp.Product> UpdateProductAsync(long productId, ShopifySharp.Product input);

    /// <summary>
    /// Deleting a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task DeleteProductAsync(long productId);

    /// <summary>
    /// Counting products
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<int> GetProductCountAsync(ProductCountFilter input);

    /// <summary>
    /// Listing products
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ListResult<ShopifySharp.Product>> GetProductListAsync(ProductListFilter input);

    /// <summary>
    /// Publishing a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<ShopifySharp.Product> UpdateProductPublishAsync(long productId);

    /// <summary>
    /// Unpublishing a product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<ShopifySharp.Product> UpdateProductUnpublishAsync(long productId);

    /// <summary>
    /// Creating a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ProductImage> CreateProductImageAsync(long productId, ProductImage input);

    /// <summary>
    /// Getting a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    Task<ProductImage> GetProductImageAsync(long productId, long imageId);

    /// <summary>
    /// Counting product images
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<int> GetProductImageCountAsync(long productId);

    /// <summary>
    /// Listing product images
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<ListResult<ProductImage>> GetProductImageListAsync(long productId);

    /// <summary>
    /// Updating a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ProductImage> UpdateProductImageAsync(long productId, long imageId, ProductImage input);

    /// <summary>
    /// Deleting a product image
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    Task DeleteProductImageAsync(long productId, long imageId);

    /// <summary>
    /// Creating a Smart Collection
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SmartCollection> CreateSmartCollection(SmartCollection input);

    /// <summary>
    /// Updating a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SmartCollection> UpdateSmartCollectionAsync(long smartCollectionId, SmartCollection input);

    /// <summary>
    /// Getting a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <returns></returns>
    Task<SmartCollection> GetSmartCollectionAsync(long smartCollectionId);

    /// <summary>
    /// Counting Smart Collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<int> GetSmartCollectionCountAsync(SmartCollectionCountFilter input);

    /// <summary>
    /// Listing Smart Collections
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ListResult<SmartCollection>> GetSmartCollectionListAsync(SmartCollectionListFilter input);

    /// <summary>
    /// Deleting a Smart Collection
    /// </summary>
    /// <param name="smartCollectionId"></param>
    /// <returns></returns>
    Task DeleteSmartCollectionAsync(long smartCollectionId);
}