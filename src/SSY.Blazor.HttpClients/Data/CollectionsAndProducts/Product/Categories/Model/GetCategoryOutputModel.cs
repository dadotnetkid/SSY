using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Categories.Model
{
    public class GetProductCategoryOutputModel
    {
        [JsonPropertyName("result")]
        public ProductCategoryModel Result { get; set; }
    }
}

