using System;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class GetAllProductOutputModel
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<ProductModel> Items { get; set; }
    }
}

