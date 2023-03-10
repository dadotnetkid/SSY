using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Model
{
    public class GetAllTypeOptionNamesModel
    {
        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("productTypeIds")]
        public List<int> ProductTypeIds { get; set; } = new();
    }
}

