using Refit;

namespace SSY.Blazor.HttpClients.RefitServices.Products.Shopifies;

public interface IShopifyApi
{
    [Post("/custom-collection/{collectionId}")]
    public Task<ApiResponse<CustomCollectionModel>> CreateCustomCollectionAsync([Body] CustomCollectionModel item, [AliasAs("collectionId")] Guid collectionId);
    [Post("/product/{productId}")]
    public Task<ApiResponse<ShopifyProductModel>> CreateProductAsync([Body] ShopifyProductModel item, [AliasAs("productId")] Guid productId);

}