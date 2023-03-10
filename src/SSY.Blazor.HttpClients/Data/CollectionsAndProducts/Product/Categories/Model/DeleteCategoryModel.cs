using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Categories.Model
{
    public class DeleteProductCategoryModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

